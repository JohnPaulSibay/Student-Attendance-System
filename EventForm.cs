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
    public partial class EventForm : Form
    {
        private Connect connect;
        public static LoginSession loginSession;
        private EventProcess eventProcess;
        public EventForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(EventPage_FormClosing);

            connect = new Connect();
            eventProcess = new EventProcess();
            textBoxEventID.KeyPress += new KeyPressEventHandler(textBoxEventID_KeyPress);
            ComboBoxMatKulNameData();
            refreshData();
        }

        private void EventPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxEventID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan input angka dan kontrol khusus (seperti Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxEventID_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxEventID.Text) && !int.TryParse(textBoxEventID.Text, out _))
            {
                MessageBox.Show("Please enter a valid Event ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEventID.Text = string.Empty;
            }

            if (textBoxEventID.Text.Length > 8)
            {
                MessageBox.Show("Event ID should be limited to 8 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEventID.Text = textBoxEventID.Text.Substring(0, 8);
                textBoxEventID.SelectionStart = textBoxEventID.Text.Length;
            }
        }

        private void ComboBoxMatKulNameData()
        {
            DataTable matkulTable = GetMatKul();

            comboBoxMatKulName.DisplayMember = "NamaMataKuliah";
            comboBoxMatKulName.ValueMember = "KodeMataKuliah";

            comboBoxMatKulName.DataSource = matkulTable;
        }

        private DataTable GetMatKul()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            string query = $"SELECT m.KodeMataKuliah, m.NamaMataKuliah FROM matakuliah m JOIN user u ON (m.UserID = u.UserID) WHERE m.UserID = {currentUserID}";
            return connect.RetrieveData(query);
        }

        private void refreshData()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            string query = $"SELECT e.EventID AS Event_ID, e.EventName AS Event_Name, m.NamaMataKuliah AS Course, e.venue AS Room, e.Tanggal AS Date FROM matakuliah m JOIN event e ON (m.KodeMataKuliah = e.KodeMataKuliah) JOIN user u ON (m.UserID = u.UserID) WHERE m.UserID = {currentUserID} ORDER BY Date DESC, Event_Name ASC, Course ASC";
            DataTable eventData = connect.RetrieveData(query);

            dataGridViewEvent.DataSource = eventData;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Event = textBoxEvent.Text;
            DataRowView selectedMatKul = (DataRowView)comboBoxMatKulName.SelectedItem;
            string kodeMK = Convert.ToString(selectedMatKul["KodeMataKuliah"]);
            string Ruang = textBoxRuang.Text;
            DateTime selectedTanggal = dateTimePickerTanggal.Value;

            if (AddEvent(Event, kodeMK, Ruang, selectedTanggal))
            {
                textBoxEvent.Clear();
                textBoxRuang.Clear();
            }
            else
            {
                MessageBox.Show("Event failed to be added.");
            }

            refreshData();
        }

        private bool AddEvent(string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                eventProcess.InputEvent(Event, kodeMK, Ruang, selectedTanggal);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEventID.Text))
            {
                MessageBox.Show("Event ID cannot be empty for update.");
                return;
            }

            int EventID = Convert.ToInt32(textBoxEventID.Text);
            string Event = textBoxEvent.Text;
            DataRowView selectedMatKul = (DataRowView)comboBoxMatKulName.SelectedItem;
            string kodeMK = Convert.ToString(selectedMatKul["KodeMataKuliah"]);
            string Ruang = textBoxRuang.Text;
            DateTime selectedTanggal = dateTimePickerTanggal.Value;

            if (EditEvent(EventID, Event, kodeMK, Ruang, selectedTanggal))
            {
                textBoxEventID.Clear();
                textBoxEvent.Clear();
                textBoxRuang.Clear();
            }
            else
            {
                MessageBox.Show("Event failed to be edited.");
            }

            refreshData();
        }

        private bool EditEvent(int EventID, string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                // Periksa apakah event dengan EventID tertentu ada di database
                if (IsEventExists(EventID))
                {
                    eventProcess.UpdateEvent(EventID, Event, kodeMK, Ruang, selectedTanggal);
                    return true;
                }
                else
                {
                    MessageBox.Show("Event ID does not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private bool IsEventExists(int EventID)
        {
            // Lakukan pengecekan apakah EventID ada di database
            string query = $"SELECT COUNT(*) FROM event WHERE EventID = {EventID}";
            int count = Convert.ToInt32(connect.ExecuteScalar(query));

            return count > 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEventID.Text))
            {
                MessageBox.Show("Event ID cannot be empty for delete.");
                return;
            }

            int EventID = Convert.ToInt32(textBoxEventID.Text);
            long DosenID = LoginPage.currentLoginSession.UserID;

            if (IsEventExists(EventID))
            {
                if (RemoveEvent(EventID, DosenID))
                {
                    textBoxEventID.Clear();
                }
                else
                {
                    MessageBox.Show("Event failed to be deleted.");
                }
            }
            else
            {
                MessageBox.Show("Event ID does not found.");
            }

            refreshData();
        }

        private bool RemoveEvent(int EventID, long DosenID)
        {
            try
            {
                eventProcess.RemoveEvent(EventID, DosenID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}