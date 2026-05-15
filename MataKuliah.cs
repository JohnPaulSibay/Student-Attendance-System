using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StudentAttendanceSystem
{
    public partial class MataKuliah : Form
    {
        private int selectedCourseId = 0;

        public MataKuliah()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(MataKuliahPage_FormClosing);
            this.Load += MataKuliah_Load;
            dataGridViewMatKul.CellClick += dataGridViewMatKul_CellClick;
        }

        private async void MataKuliah_Load(object sender, EventArgs e)
        {
            await LoadLecturersFromApi();
            refreshData();
        }

        private async Task LoadLecturersFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/lecturers");

                    LecturerApiResponse response =
                        JsonConvert.DeserializeObject<LecturerApiResponse>(json);

                    comboBoxDosenPengampu.DataSource = null;
                    comboBoxDosenPengampu.DisplayMember = "teacher_name";
                    comboBoxDosenPengampu.ValueMember = "teacher_id";
                    comboBoxDosenPengampu.DataSource = response.data;
                    comboBoxDosenPengampu.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load lecturers from API: " + ex.Message);
            }
        }

        private void MataKuliahPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClearInputs()
        {
            selectedCourseId = 0;
            textBoxMatKul.Clear();
            textBoxMatKulName.Clear();

            if (comboBoxDosenPengampu.Items.Count > 0)
                comboBoxDosenPengampu.SelectedIndex = -1;
        }

        private async void refreshData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/courses");

                    CourseApiResponse response =
                        JsonConvert.DeserializeObject<CourseApiResponse>(json);

                    dataGridViewMatKul.DataSource = response.data;

                    dataGridViewMatKul.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewMatKul.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewMatKul.MultiSelect = false;
                    dataGridViewMatKul.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load courses from API: " + ex.Message);
            }
        }

        private void dataGridViewMatKul_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridViewMatKul.Rows[e.RowIndex];

            selectedCourseId = Convert.ToInt32(row.Cells["course_id"].Value);
            textBoxMatKul.Text = row.Cells["course_code"].Value.ToString();
            textBoxMatKulName.Text = row.Cells["course_name"].Value.ToString();

            if (row.Cells["teacher_id"].Value != null && row.Cells["teacher_id"].Value != DBNull.Value)
            {
                comboBoxDosenPengampu.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);
            }
            else if (row.Cells["lecturer"].Value != null)
            {
                comboBoxDosenPengampu.Text = row.Cells["lecturer"].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            refreshData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string courseCode = textBoxMatKul.Text.Trim();
                string courseName = textBoxMatKulName.Text.Trim();

                if (string.IsNullOrWhiteSpace(courseCode) || string.IsNullOrWhiteSpace(courseName))
                {
                    MessageBox.Show("Course ID and Course Name must not be blank.");
                    return;
                }

                if (comboBoxDosenPengampu.SelectedItem == null)
                {
                    MessageBox.Show("Please select a lecturer.");
                    return;
                }

                Lecturer selectedLecturer = (Lecturer)comboBoxDosenPengampu.SelectedItem;

                var courseData = new
                {
                    course_code = courseCode,
                    course_name = courseName,
                    teacher_id = selectedLecturer.teacher_id
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(courseData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(
                        "http://localhost:3000/api/courses",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Course added successfully!");
                        ClearInputs();
                        refreshData();
                    }
                    else
                    {
                        MessageBox.Show("Add failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCourseId == 0)
                {
                    MessageBox.Show("Please select a course row first.");
                    return;
                }

                string courseCode = textBoxMatKul.Text.Trim();
                string courseName = textBoxMatKulName.Text.Trim();

                if (string.IsNullOrWhiteSpace(courseCode) || string.IsNullOrWhiteSpace(courseName))
                {
                    MessageBox.Show("Course ID and Course Name must not be blank.");
                    return;
                }

                if (comboBoxDosenPengampu.SelectedItem == null)
                {
                    MessageBox.Show("Please select a lecturer.");
                    return;
                }

                Lecturer selectedLecturer = (Lecturer)comboBoxDosenPengampu.SelectedItem;

                var courseData = new
                {
                    course_code = courseCode,
                    course_name = courseName,
                    teacher_id = selectedLecturer.teacher_id
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(courseData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(
                        $"http://localhost:3000/api/courses/{selectedCourseId}",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Course updated successfully!");
                        ClearInputs();
                        refreshData();
                    }
                    else
                    {
                        MessageBox.Show("Update failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCourseId == 0)
                {
                    MessageBox.Show("Please select a course row first.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this course?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(
                        $"http://localhost:3000/api/courses/{selectedCourseId}"
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Course deleted successfully!");
                        ClearInputs();
                        refreshData();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed: " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (LoginPage.currentLoginSession.UserRole == 1)
            {
                AdministratorPage adminPage = new AdministratorPage();
                adminPage.Show();
            }
            else if (LoginPage.currentLoginSession.UserRole == 2)
            {
                LecturerPage lecturerPage = new LecturerPage();
                lecturerPage.Show();
            }
            else if (LoginPage.currentLoginSession.UserRole == 3)
            {
                StudentPage studentPage = new StudentPage();
                studentPage.Show();
            }
            else
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
            }

            this.Hide();
        }
    }
}
