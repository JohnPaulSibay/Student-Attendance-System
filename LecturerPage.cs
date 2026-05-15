using System;
using System.Windows.Forms;

namespace StudentAttendanceSystem
{
    public partial class LecturerPage : Form
    {
        public LecturerPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(LecturerPage_FormClosing);
        }

        private void LecturerPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool IsLecturerAccountLinked()
        {
            if (LoginPage.currentLoginSession == null)
            {
                MessageBox.Show("Session expired. Please log in again.");
                new LoginPage().Show();
                this.Hide();
                return false;
            }

            if (LoginPage.currentLoginSession.TeacherID == null)
            {
                MessageBox.Show(
                    "This lecturer account is not linked to a central lecturer record. Please update the user account link in User Management.",
                    "Account Link Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
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
                    LoginPage.currentLoginSession.ClearLoginSession();

                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {
            if (!IsLecturerAccountLinked())
                return;

            AttendancePage attendancePage = new AttendancePage();
            attendancePage.Show();
            this.Hide();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            if (!IsLecturerAccountLinked())
                return;

            EventPage eventPage = new EventPage();
            eventPage.Show();
            this.Hide();
        }
    }
}
