using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendanceSystem
{
    public partial class AdministratorPage : Form
    {
        public AdministratorPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(AdministratorPage_FormClosing);
        }

        private void AdministratorPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                if (LoginPage.currentLoginSession != null)
                {
                    LoginPage.currentLoginSession.ClearLoginSession();
                }

                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserPage userPage = new UserPage();
            userPage.Show();
            this.Hide();
        }

        private void btnMatkul_Click(object sender, EventArgs e)
        {
            MataKuliah mataKuliah = new MataKuliah();
            mataKuliah.Show();
            this.Hide();
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            AttendancePage attendancePage = new AttendancePage();
            attendancePage.Show();
            this.Hide();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            EventPage eventPage = new EventPage();
            eventPage.Show();
            this.Hide();
        }
    }
}
