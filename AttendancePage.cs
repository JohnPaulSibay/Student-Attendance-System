using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace StudentAttendanceSystem
{
    public partial class AttendancePage : Form
    {

        public AttendancePage()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(AttendancePage_FormClosing);
            this.Load += AttendancePage_Load;


            textBoxPresensiID.KeyPress += new KeyPressEventHandler(textBoxPresensiID_KeyPress);

            dataGridViewAttendance.CellClick += dataGridViewAttendance_CellClick;
            dataGridViewAttendance.CellFormatting += dataGridViewAttendance_CellFormatting;
            txtSearch.KeyDown += txtSearch_KeyDown;
            txtSearch.ForeColor = Color.Black;

        }

        private async void AttendancePage_Load(object sender, EventArgs e)
        {
            await LoadAttendanceStatusesFromApi();
            await LoadStudentsFromApi();
            await LoadEventsFromApi();
            await RefreshDataFromApi();
        }

        private async Task LoadStudentsFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/students");

                    StudentApiResponse response =
                        JsonConvert.DeserializeObject<StudentApiResponse>(json);

                    if (response == null || response.data == null || response.data.Count == 0)
                    {
                        MessageBox.Show("No students received from API.");
                        return;
                    }

                    comboBoxStudent.DataSource = null;
                    comboBoxStudent.DisplayMember = "FullName";
                    comboBoxStudent.ValueMember = "student_id";
                    comboBoxStudent.DataSource = response.data;
                    comboBoxStudent.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message);
            }
        }

        private async Task LoadEventsFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/events");

                    EventApiResponse response =
                        JsonConvert.DeserializeObject<EventApiResponse>(json);

                    if (response == null || response.data == null)
                    {
                        MessageBox.Show("No events received from API.");
                        return;
                    }

                    var events = response.data;

                    if (LoginPage.currentLoginSession != null &&
                        LoginPage.currentLoginSession.UserRole == 2 &&
                        LoginPage.currentLoginSession.TeacherID != null)
                    {
                        events = events
                            .Where(x => x.teacher_id == LoginPage.currentLoginSession.TeacherID)
                            .ToList();
                    }

                    comboBoxEvent.DataSource = null;
                    comboBoxEvent.DisplayMember = "event_name";
                    comboBoxEvent.ValueMember = "event_id";
                    comboBoxEvent.DataSource = events;
                    comboBoxEvent.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load events from API: " + ex.Message);
            }
        }

        private async Task RefreshDataFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:3000/api/attendance";

                    if (LoginPage.currentLoginSession != null &&
                        LoginPage.currentLoginSession.UserRole == 2)
                    {
                        if (LoginPage.currentLoginSession.TeacherID == null)
                        {
                            MessageBox.Show("Lecturer account is not linked properly.");
                            return;
                        }

                        url = "http://localhost:3000/api/attendance/lecturer/" +
                              LoginPage.currentLoginSession.TeacherID;
                    }

                    string json = await client.GetStringAsync(url);

                    AttendanceApiResponse response =
                        JsonConvert.DeserializeObject<AttendanceApiResponse>(json);

                    dataGridViewAttendance.DataSource = response.data;
                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load attendance from API: " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAttendance.MultiSelect = false;
            dataGridViewAttendance.ReadOnly = true;
        }

        private void ClearInputs()
        {
            textBoxPresensiID.Clear();

            if (comboBoxStudent.Items.Count > 0)
                comboBoxStudent.SelectedIndex = -1;

            if (comboBoxEvent.Items.Count > 0)
                comboBoxEvent.SelectedIndex = -1;

            if (comboBoxKehadiran.Items.Count > 0)
                comboBoxKehadiran.SelectedIndex = -1;
        }

        private void AttendancePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPresensiID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPresensiID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPresensiID.Text) && !int.TryParse(textBoxPresensiID.Text, out _))
            {
                MessageBox.Show("Please enter a valid Attendance ID.");
                textBoxPresensiID.Text = string.Empty;
            }
        }

        private async Task LoadAttendanceStatusesFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/attendance/statuses");

                    AttendanceStatusApiResponse response =
                        JsonConvert.DeserializeObject<AttendanceStatusApiResponse>(json);

                    if (response == null || response.data == null || response.data.Count == 0)
                    {
                        MessageBox.Show("No attendance statuses received from API.");
                        return;
                    }

                    comboBoxKehadiran.DataSource = null;
                    comboBoxKehadiran.DisplayMember = "label";
                    comboBoxKehadiran.ValueMember = "value";
                    comboBoxKehadiran.DataSource = response.data;
                    comboBoxKehadiran.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load attendance statuses from API: " + ex.Message);
            }
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAttendanceStatusesFromApi();
            await LoadStudentsFromApi();
            await LoadEventsFromApi();
            await RefreshDataFromApi();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxStudent.SelectedItem == null)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                if (comboBoxEvent.SelectedItem == null)
                {
                    MessageBox.Show("Please select an event.");
                    return;
                }

                if (comboBoxKehadiran.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.");
                    return;
                }

                Student selectedStudent = (Student)comboBoxStudent.SelectedItem;
                AttendanceStatus selectedStatus = (AttendanceStatus)comboBoxKehadiran.SelectedItem;
                string statusText = selectedStatus.value;

                ApiEvent selectedEvent = (ApiEvent)comboBoxEvent.SelectedItem;

                var attendanceData = new
                {
                    student_id = selectedStudent.student_id,
                    event_id = selectedEvent.event_id,
                    attendance_date = DateTime.Now.ToString("yyyy-MM-dd"),
                    status = statusText,
                    time_in = DateTime.Now.ToString("HH:mm:ss"),
                    remarks = "Recorded from C# Attendance System"
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(attendanceData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(
                        "http://localhost:3000/api/attendance",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Attendance saved to API successfully!");
                        ClearInputs();
                        await RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("API Error: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPresensiID.Text))
                {
                    MessageBox.Show("Enter Attendance ID");
                    return;
                }

                if (comboBoxStudent.SelectedItem == null)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                if (comboBoxKehadiran.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.");
                    return;
                }

                if (comboBoxEvent.SelectedItem == null)
                {
                    MessageBox.Show("Please select an event.");
                    return;
                }

                int attendanceId = Convert.ToInt32(textBoxPresensiID.Text);
                Student selectedStudent = (Student)comboBoxStudent.SelectedItem;
                ApiEvent selectedEvent = (ApiEvent)comboBoxEvent.SelectedItem;

                AttendanceStatus selectedStatus = (AttendanceStatus)comboBoxKehadiran.SelectedItem;
                string statusText = selectedStatus.value;

                var updateData = new
                {
                    student_id = selectedStudent.student_id,
                    event_id = selectedEvent.event_id,
                    status = statusText
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(updateData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(
                        $"http://localhost:3000/api/attendance/{attendanceId}",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Updated successfully!");
                        ClearInputs();
                        await RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("Update failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPresensiID.Text))
                {
                    MessageBox.Show("Enter Attendance ID");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this attendance record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                int attendanceId = Convert.ToInt32(textBoxPresensiID.Text);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(
                        $"http://localhost:3000/api/attendance/{attendanceId}"
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Deleted successfully!");
                        ClearInputs();
                        await RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridViewAttendance.Rows[e.RowIndex];

            if (row.Cells["attendance_id"].Value != null)
                textBoxPresensiID.Text = row.Cells["attendance_id"].Value.ToString();

            if (row.Cells["student_id"].Value != null && row.Cells["student_id"].Value != DBNull.Value)
                comboBoxStudent.SelectedValue = Convert.ToInt32(row.Cells["student_id"].Value);
            else if (row.Cells["student_name"].Value != null)
                comboBoxStudent.Text = row.Cells["student_name"].Value.ToString();

            if (row.Cells["event_id"].Value != null && row.Cells["event_id"].Value != DBNull.Value)
                comboBoxEvent.SelectedValue = Convert.ToInt32(row.Cells["event_id"].Value);

            if (row.Cells["status"].Value != null)
                comboBoxKehadiran.SelectedValue = row.Cells["status"].Value.ToString();
        }

        private void dataGridViewAttendance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewAttendance.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Present")
                    e.CellStyle.ForeColor = Color.Green;
                else if (status == "Absent")
                    e.CellStyle.ForeColor = Color.Red;
                else if (status == "Permission")
                    e.CellStyle.ForeColor = Color.Blue;
                else if (status == "Medical Leave")
                    e.CellStyle.ForeColor = Color.Orange;
                else if (status == "Late")
                    e.CellStyle.ForeColor = Color.Purple;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (LoginPage.currentLoginSession.UserRole == 1)
                new AdministratorPage().Show();
            else if (LoginPage.currentLoginSession.UserRole == 2)
                new LecturerPage().Show();
            else if (LoginPage.currentLoginSession.UserRole == 3)
                new StudentPage().Show();
            else
                new LoginPage().Show();

            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<AttendanceRecord> records = dataGridViewAttendance.DataSource as List<AttendanceRecord>;

            if (records == null || records.Count == 0)
            {
                MessageBox.Show("No data.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Attendance_ID,Student_Number,Student_Name,Subject,Teacher,Date,Status,Time_In,Remarks");

                foreach (AttendanceRecord row in records)
                {
                    sb.AppendLine($"{row.attendance_id},{row.student_number},{row.student_name},{row.subject_name},{row.teacher_name},{row.attendance_date},{row.status},{row.time_in},{row.remarks}");
                }

                File.WriteAllText(sfd.FileName, sb.ToString());
                MessageBox.Show("Exported!");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await SearchAttendance();
        }

        private async void btnSearch_Click_1(object sender, EventArgs e)
        {
            await SearchAttendance();
        }

        private string GetAttendanceApiUrl()
        {
            if (LoginPage.currentLoginSession != null &&
                LoginPage.currentLoginSession.UserRole == 2)
            {
                if (LoginPage.currentLoginSession.TeacherID == null)
                {
                    MessageBox.Show("Lecturer account is not linked properly.");
                    return null;
                }

                return "http://localhost:3000/api/attendance/lecturer/" +
                       LoginPage.currentLoginSession.TeacherID;
            }

            return "http://localhost:3000/api/attendance";
        }

        private async Task SearchAttendance()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = GetAttendanceApiUrl();
                    if (url == null)
                        return;

                    string json = await client.GetStringAsync(url);

                    AttendanceApiResponse response =
                        JsonConvert.DeserializeObject<AttendanceApiResponse>(json);

                    List<AttendanceRecord> records = response != null && response.data != null
                        ? response.data
                        : new List<AttendanceRecord>();

                    string keyword = txtSearch.Text.Trim().ToLower();

                    if (records.Count == 0)
                    {
                        dataGridViewAttendance.DataSource = records;
                        FormatGrid();

                        if (LoginPage.currentLoginSession != null && LoginPage.currentLoginSession.UserRole == 2)
                        {
                            MessageBox.Show(
                                "No attendance records found for this lecturer account. Add attendance for this lecturer's course/event first, or check the lecturer account link in User Management.",
                                "No Lecturer Attendance",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(keyword))
                    {
                        dataGridViewAttendance.DataSource = records;
                    }
                    else
                    {
                        var filtered = records
                            .Where(x =>
                                x.attendance_id.ToString().Contains(keyword) ||
                                x.student_id.ToString().Contains(keyword) ||
                                (x.event_id != null && x.event_id.ToString().Contains(keyword)) ||
                                ContainsKeyword(x.student_number, keyword) ||
                                ContainsKeyword(x.student_name, keyword) ||
                                ContainsKeyword(x.event_name, keyword) ||
                                ContainsKeyword(x.subject_code, keyword) ||
                                ContainsKeyword(x.subject_name, keyword) ||
                                ContainsKeyword(x.teacher_name, keyword) ||
                                ContainsKeyword(x.status, keyword) ||
                                ContainsKeyword(x.attendance_date, keyword) ||
                                ContainsKeyword(x.time_in, keyword) ||
                                ContainsKeyword(x.remarks, keyword)
                            )
                            .ToList();

                        dataGridViewAttendance.DataSource = filtered;

                        if (filtered.Count == 0)
                        {
                            MessageBox.Show("No matching attendance records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    FormatGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private bool ContainsKeyword(string value, string keyword)
        {
            return !string.IsNullOrEmpty(value) && value.ToLower().Contains(keyword);
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await SearchAttendance();
            }
        }
        private void AttendancePage_Load_1(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}







