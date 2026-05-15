using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StudentAttendanceSystem
{
    public partial class LoginPage : Form
    {
        public static LoginSession currentLoginSession;

        public LoginPage()
        {
            InitializeComponent();
            this.FormClosing += LoginPage_FormClosing;
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxEmail.Text.Trim();
                string password = textBoxPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter username and password.");
                    return;
                }

                var loginData = new
                {
                    username = username,
                    password = password
                };

                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(loginData);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(
                        "http://localhost:3000/api/login",
                        content
                    );

                    string result = await response.Content.ReadAsStringAsync();

                    LoginResponse loginResponse =
                        JsonConvert.DeserializeObject<LoginResponse>(result);

                    if (response.IsSuccessStatusCode && loginResponse.status == "success")
                    {
                        int roleNumber = ConvertRoleToNumber(loginResponse.user.role);

                        currentLoginSession = new LoginSession(
                            loginResponse.user.username,
                            roleNumber,
                            loginResponse.user.user_id,
                            loginResponse.user.student_id,
                            loginResponse.user.teacher_id
                        );

                        OpenHomePage(loginResponse.user.role);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(loginResponse.message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
            }
        }

        private int ConvertRoleToNumber(string role)
        {
            if (role == "Administrator") return 1;
            if (role == "Lecturer") return 2;
            if (role == "Student") return 3;
            return 0;
        }

        private void OpenHomePage(string role)
        {
            if (role == "Administrator")
                new AdministratorPage().Show();
            else if (role == "Lecturer")
                new LecturerPage().Show();
            else if (role == "Student")
                new StudentPage().Show();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '●';
        }
    }

    public class LoginSession
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }

        // ✅ ADD THIS (alias for old code)
        public string Email { get { return Username; } }

        public int UserRole { get; private set; }
        public int? StudentID { get; private set; }
        public int? TeacherID { get; private set; }

        public LoginSession(string username, int role, int userId, int? studentId, int? teacherId)
        {
            Username = username;
            UserRole = role;
            UserID = userId;
            StudentID = studentId;
            TeacherID = teacherId;
        }

        // ✅ ADD THIS BACK
        public void ClearLoginSession()
        {
            Username = null;
            UserRole = 0;
            UserID = 0;
            StudentID = null;
            TeacherID = null;
        }
    }
}