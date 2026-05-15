using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StudentAttendanceSystem
{
    public partial class StudentPage : Form
    {
        public StudentPage()
        {
            InitializeComponent();
            this.FormClosing += StudentPage_FormClosing;
            LoadAttendance();
        }

        private void StudentPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void LoadAttendance()
        {
            try
            {
                int? studentId = LoginPage.currentLoginSession.StudentID;

                if (studentId == null)
                {
                    MessageBox.Show("Student account not linked properly.");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:3000/api/attendance/student/" + studentId;

                    string json = await client.GetStringAsync(url);

                    AttendanceApiResponse response =
                        JsonConvert.DeserializeObject<AttendanceApiResponse>(json);

                    dataGridViewAttendance.DataSource = response.data;
                    dataGridViewAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new LoginPage().Show();
            this.Hide();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export feature ready.");
        }
    }
}