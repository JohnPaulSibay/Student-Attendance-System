using System;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StudentAttendanceSystem
{
    public partial class EventPage : Form
    {
        private int selectedEventId = 0;

        public EventPage()
        {
            InitializeComponent();

            this.FormClosing += EventPage_FormClosing;
            dataGridViewEvent.CellClick += dataGridViewEvent_CellClick;

            LoadCoursesFromApi();
            RefreshDataFromApi();
        }

        private void EventPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void LoadCoursesFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/courses");

                    CourseApiResponse response =
                        JsonConvert.DeserializeObject<CourseApiResponse>(json);

                    var courses = response.data;

                    if (LoginPage.currentLoginSession != null &&
                        LoginPage.currentLoginSession.UserRole == 2 &&
                        LoginPage.currentLoginSession.TeacherID != null)
                    {
                        courses = courses
                            .Where(x => x.teacher_id == LoginPage.currentLoginSession.TeacherID)
                            .ToList();
                    }

                    comboBoxMatKulName.DataSource = null;
                    comboBoxMatKulName.DisplayMember = "course_name";
                    comboBoxMatKulName.ValueMember = "course_id";
                    comboBoxMatKulName.DataSource = courses;
                    comboBoxMatKulName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load courses: " + ex.Message);
            }
        }

        private async void RefreshDataFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/events");

                    EventApiResponse response =
                        JsonConvert.DeserializeObject<EventApiResponse>(json);

                    var events = response.data;

                    if (LoginPage.currentLoginSession != null &&
                        LoginPage.currentLoginSession.UserRole == 2 &&
                        LoginPage.currentLoginSession.TeacherID != null)
                    {
                        events = events
                            .Where(x => x.teacher_id == LoginPage.currentLoginSession.TeacherID)
                            .ToList();
                    }

                    dataGridViewEvent.DataSource = events;
                    dataGridViewEvent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewEvent.MultiSelect = false;
                    dataGridViewEvent.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load events: " + ex.Message);
            }
        }

        private void dataGridViewEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewEvent.Rows[e.RowIndex];

            selectedEventId = Convert.ToInt32(row.Cells["event_id"].Value);
            textBoxEventID.Text = selectedEventId.ToString();
            textBoxEvent.Text = row.Cells["event_name"].Value.ToString();
            textBoxRuang.Text = row.Cells["room"].Value == null ? "" : row.Cells["room"].Value.ToString();

            if (row.Cells["course_id"].Value != null && row.Cells["course_id"].Value != DBNull.Value)
                comboBoxMatKulName.SelectedValue = Convert.ToInt32(row.Cells["course_id"].Value);

            if (row.Cells["event_date"].Value != null)
            {
                DateTime dateValue;
                if (DateTime.TryParse(row.Cells["event_date"].Value.ToString(), out dateValue))
                {
                    dateTimePickerTanggal.Value = dateValue;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMatKulName.SelectedItem == null)
                {
                    MessageBox.Show("Select course first.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEvent.Text))
                {
                    MessageBox.Show("Event name is required.");
                    return;
                }

                var eventData = new
                {
                    event_name = textBoxEvent.Text.Trim(),
                    course_id = Convert.ToInt32(comboBoxMatKulName.SelectedValue),
                    room = textBoxRuang.Text.Trim(),
                    event_date = dateTimePickerTanggal.Value.ToString("yyyy-MM-dd")
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(eventData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(
                        "http://localhost:3000/api/events",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Event added!");
                        ClearInputs();
                        RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("Add failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding event: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedEventId == 0)
                {
                    MessageBox.Show("Select event first.");
                    return;
                }

                if (comboBoxMatKulName.SelectedItem == null)
                {
                    MessageBox.Show("Select course first.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxEvent.Text))
                {
                    MessageBox.Show("Event name is required.");
                    return;
                }

                var eventData = new
                {
                    event_name = textBoxEvent.Text.Trim(),
                    course_id = Convert.ToInt32(comboBoxMatKulName.SelectedValue),
                    room = textBoxRuang.Text.Trim(),
                    event_date = dateTimePickerTanggal.Value.ToString("yyyy-MM-dd")
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(eventData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(
                        $"http://localhost:3000/api/events/{selectedEventId}",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Event updated!");
                        ClearInputs();
                        RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("Update failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating event: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedEventId == 0)
                {
                    MessageBox.Show("Select event first.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this event?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(
                        $"http://localhost:3000/api/events/{selectedEventId}"
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Event deleted!");
                        ClearInputs();
                        RefreshDataFromApi();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting event: " + ex.Message);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadCoursesFromApi();
            RefreshDataFromApi();
        }

        private void ClearInputs()
        {
            selectedEventId = 0;
            textBoxEventID.Clear();
            textBoxEvent.Clear();
            textBoxRuang.Clear();

            if (comboBoxMatKulName.Items.Count > 0)
                comboBoxMatKulName.SelectedIndex = -1;
        }

        private void textBoxEventID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEventID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEventID.Text) && !int.TryParse(textBoxEventID.Text, out _))
            {
                MessageBox.Show("Please enter a valid Event ID.");
                textBoxEventID.Text = string.Empty;
            }
        }
    }
}

