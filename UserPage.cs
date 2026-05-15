using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StudentAttendanceSystem
{
    public partial class UserPage : Form
    {
        private int selectedUserId = 0;

        public UserPage()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(UserPage_FormClosing);
            dataGridViewUser.CellClick += dataGridViewUser_CellClick;
            comboBoxRole.SelectedIndexChanged += comboBoxRole_SelectedIndexChanged;

            LoadRoles();
            LoadLinkOptions();
            refreshData();
        }

        private void UserPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LoadRoles()
        {
            comboBoxRole.Items.Clear();
            comboBoxRole.Items.Add("Administrator");
            comboBoxRole.Items.Add("Lecturer");
            comboBoxRole.Items.Add("Student");
            comboBoxRole.SelectedIndex = -1;
            UpdateLinkControls();
        }

        private async void LoadLinkOptions()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string studentJson = await client.GetStringAsync("http://localhost:3000/api/students");
                    StudentApiResponse studentResponse =
                        JsonConvert.DeserializeObject<StudentApiResponse>(studentJson);

                    comboBoxStudentLink.DataSource = null;
                    comboBoxStudentLink.DisplayMember = "FullName";
                    comboBoxStudentLink.ValueMember = "student_id";
                    comboBoxStudentLink.DataSource = studentResponse.data;
                    comboBoxStudentLink.SelectedIndex = -1;

                    string lecturerJson = await client.GetStringAsync("http://localhost:3000/api/lecturers");
                    LecturerApiResponse lecturerResponse =
                        JsonConvert.DeserializeObject<LecturerApiResponse>(lecturerJson);

                    comboBoxLecturerLink.DataSource = null;
                    comboBoxLecturerLink.DisplayMember = "teacher_name";
                    comboBoxLecturerLink.ValueMember = "teacher_id";
                    comboBoxLecturerLink.DataSource = lecturerResponse.data;
                    comboBoxLecturerLink.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load student/lecturer link options: " + ex.Message);
            }
        }

        private void UpdateLinkControls()
        {
            string role = comboBoxRole.Text.Trim();

            bool isStudent = role == "Student";
            bool isLecturer = role == "Lecturer";

            lblStudentLink.Enabled = isStudent;
            comboBoxStudentLink.Enabled = isStudent;
            lblLecturerLink.Enabled = isLecturer;
            comboBoxLecturerLink.Enabled = isLecturer;

            if (!isStudent && comboBoxStudentLink.Items.Count > 0)
                comboBoxStudentLink.SelectedIndex = -1;

            if (!isLecturer && comboBoxLecturerLink.Items.Count > 0)
                comboBoxLecturerLink.SelectedIndex = -1;
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLinkControls();
        }

        private int? GetSelectedStudentId(string role)
        {
            if (role != "Student" || comboBoxStudentLink.SelectedValue == null)
                return null;

            return Convert.ToInt32(comboBoxStudentLink.SelectedValue);
        }

        private int? GetSelectedTeacherId(string role)
        {
            if (role != "Lecturer" || comboBoxLecturerLink.SelectedValue == null)
                return null;

            return Convert.ToInt32(comboBoxLecturerLink.SelectedValue);
        }

        private void ClearInputs()
        {
            selectedUserId = 0;
            textBoxUserId.Clear();
            textBoxName.Clear();
            textBoxEmail.Clear();
            textBoxPassword.Clear();
            comboBoxRole.SelectedIndex = -1;
            if (comboBoxStudentLink.Items.Count > 0) comboBoxStudentLink.SelectedIndex = -1;
            if (comboBoxLecturerLink.Items.Count > 0) comboBoxLecturerLink.SelectedIndex = -1;
            UpdateLinkControls();
        }

        private async void refreshData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync("http://localhost:3000/api/users");

                    UserApiResponse response =
                        JsonConvert.DeserializeObject<UserApiResponse>(json);

                    dataGridViewUser.DataSource = response.data;

                    dataGridViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewUser.MultiSelect = false;
                    dataGridViewUser.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users from API: " + ex.Message);
            }
        }

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridViewUser.Rows[e.RowIndex];

            selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);
            textBoxUserId.Text = selectedUserId.ToString();
            textBoxName.Text = row.Cells["full_name"].Value.ToString();
            textBoxEmail.Text = row.Cells["username"].Value.ToString();
            textBoxPassword.Text = "";
            comboBoxRole.Text = row.Cells["role"].Value.ToString();
            UpdateLinkControls();

            if (row.Cells["student_id"].Value != null && row.Cells["student_id"].Value != DBNull.Value)
                comboBoxStudentLink.SelectedValue = Convert.ToInt32(row.Cells["student_id"].Value);

            if (row.Cells["teacher_id"].Value != null && row.Cells["teacher_id"].Value != DBNull.Value)
                comboBoxLecturerLink.SelectedValue = Convert.ToInt32(row.Cells["teacher_id"].Value);
        }

        private void textBoxUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxUserId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxUserId.Text) && !long.TryParse(textBoxUserId.Text, out _))
            {
                MessageBox.Show("Please enter a valid User ID.");
                textBoxUserId.Text = string.Empty;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadLinkOptions();
            refreshData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = textBoxName.Text.Trim();
                string username = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text.Trim();
                string role = comboBoxRole.Text.Trim();

                if (string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Name, email/username, password, and role are required.");
                    return;
                }

                if (role == "Student" && comboBoxStudentLink.SelectedItem == null)
                {
                    MessageBox.Show("Please link this user to a central student record.");
                    return;
                }

                if (role == "Lecturer" && comboBoxLecturerLink.SelectedItem == null)
                {
                    MessageBox.Show("Please link this user to a central lecturer record.");
                    return;
                }

                var userData = new
                {
                    full_name = fullName,
                    username = username,
                    password = password,
                    role = role,
                    student_id = GetSelectedStudentId(role),
                    teacher_id = GetSelectedTeacherId(role)
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(userData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(
                        "http://localhost:3000/api/users",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User added successfully!");
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
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedUserId == 0)
                {
                    MessageBox.Show("Please select a user row first.");
                    return;
                }

                string fullName = textBoxName.Text.Trim();
                string username = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text.Trim();
                string role = comboBoxRole.Text.Trim();

                if (string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Name, email/username, and role are required. Enter password only when changing it.");
                    return;
                }

                if (role == "Student" && comboBoxStudentLink.SelectedItem == null)
                {
                    MessageBox.Show("Please link this user to a central student record.");
                    return;
                }

                if (role == "Lecturer" && comboBoxLecturerLink.SelectedItem == null)
                {
                    MessageBox.Show("Please link this user to a central lecturer record.");
                    return;
                }

                var userData = new
                {
                    full_name = fullName,
                    username = username,
                    password = password,
                    role = role,
                    student_id = GetSelectedStudentId(role),
                    teacher_id = GetSelectedTeacherId(role)
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(userData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(
                        $"http://localhost:3000/api/users/{selectedUserId}",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User updated successfully!");
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
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedUserId == 0)
                {
                    MessageBox.Show("Please select a user row first.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm != DialogResult.Yes)
                    return;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.DeleteAsync(
                        $"http://localhost:3000/api/users/{selectedUserId}"
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User deleted successfully!");
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
                MessageBox.Show("Error deleting user: " + ex.Message);
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



