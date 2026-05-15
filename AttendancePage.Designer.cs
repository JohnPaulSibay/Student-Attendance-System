namespace StudentAttendanceSystem
{
    partial class AttendancePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPresensiID = new System.Windows.Forms.Label();
            this.textBoxPresensiID = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewAttendance = new System.Windows.Forms.DataGridView();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxKehadiran = new System.Windows.Forms.ComboBox();
            this.lblKehadiran = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPresensiID
            // 
            this.lblPresensiID.AutoSize = true;
            this.lblPresensiID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresensiID.Location = new System.Drawing.Point(5, 14);
            this.lblPresensiID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPresensiID.Name = "lblPresensiID";
            this.lblPresensiID.Size = new System.Drawing.Size(121, 20);
            this.lblPresensiID.TabIndex = 38;
            this.lblPresensiID.Text = "Attendance ID :";
            // 
            // textBoxPresensiID
            // 
            this.textBoxPresensiID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPresensiID.Location = new System.Drawing.Point(132, 12);
            this.textBoxPresensiID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPresensiID.Name = "textBoxPresensiID";
            this.textBoxPresensiID.Size = new System.Drawing.Size(187, 26);
            this.textBoxPresensiID.TabIndex = 1;
            this.textBoxPresensiID.TextChanged += new System.EventHandler(this.textBoxPresensiID_TextChanged);
            this.textBoxPresensiID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPresensiID_KeyPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(428, 94);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(73, 28);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(428, 52);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 32);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(340, 90);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(73, 32);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(340, 52);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 32);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewAttendance
            // 
            this.dataGridViewAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendance.Location = new System.Drawing.Point(8, 201);
            this.dataGridViewAttendance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewAttendance.Name = "dataGridViewAttendance";
            this.dataGridViewAttendance.ReadOnly = true;
            this.dataGridViewAttendance.RowHeadersWidth = 62;
            this.dataGridViewAttendance.RowTemplate.Height = 28;
            this.dataGridViewAttendance.Size = new System.Drawing.Size(636, 210);
            this.dataGridViewAttendance.TabIndex = 32;
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Location = new System.Drawing.Point(132, 88);
            this.comboBoxEvent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(187, 28);
            this.comboBoxEvent.TabIndex = 3;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.Location = new System.Drawing.Point(5, 52);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(74, 20);
            this.lblStudent.TabIndex = 26;
            this.lblStudent.Text = "Student :";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(5, 90);
            this.lblEvent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(58, 20);
            this.lblEvent.TabIndex = 25;
            this.lblEvent.Text = "Event :";
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(132, 50);
            this.comboBoxStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(187, 28);
            this.comboBoxStudent.TabIndex = 2;
            // 
            // comboBoxKehadiran
            // 
            this.comboBoxKehadiran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKehadiran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxKehadiran.FormattingEnabled = true;
            this.comboBoxKehadiran.Location = new System.Drawing.Point(132, 127);
            this.comboBoxKehadiran.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxKehadiran.Name = "comboBoxKehadiran";
            this.comboBoxKehadiran.Size = new System.Drawing.Size(187, 28);
            this.comboBoxKehadiran.TabIndex = 4;
            // 
            // lblKehadiran
            // 
            this.lblKehadiran.AutoSize = true;
            this.lblKehadiran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKehadiran.Location = new System.Drawing.Point(5, 129);
            this.lblKehadiran.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKehadiran.Name = "lblKehadiran";
            this.lblKehadiran.Size = new System.Drawing.Size(64, 20);
            this.lblKehadiran.TabIndex = 39;
            this.lblKehadiran.Text = "Status :";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Sienna;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(561, 4);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(83, 30);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(323, 4);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(63, 30);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSearch.Location = new System.Drawing.Point(388, 171);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 22);
            this.txtSearch.TabIndex = 40;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(580, 170);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 26);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Search by ID, Student, or Status:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AttendancePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(656, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboBoxKehadiran);
            this.Controls.Add(this.lblKehadiran);
            this.Controls.Add(this.lblPresensiID);
            this.Controls.Add(this.textBoxPresensiID);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAttendance);
            this.Controls.Add(this.comboBoxEvent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.comboBoxStudent);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 469);
            this.MinimumSize = new System.Drawing.Size(672, 469);
            this.Name = "AttendancePage";
            this.Text = "Attendance";
            this.Load += new System.EventHandler(this.AttendancePage_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPresensiID;
        private System.Windows.Forms.TextBox textBoxPresensiID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewAttendance;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxKehadiran;
        private System.Windows.Forms.Label lblKehadiran;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
    }
}