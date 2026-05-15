namespace StudentAttendanceSystem
{
    partial class UserPage
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
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.lblStudentLink = new System.Windows.Forms.Label();
            this.comboBoxStudentLink = new System.Windows.Forms.ComboBox();
            this.lblLecturerLink = new System.Windows.Forms.Label();
            this.comboBoxLecturerLink = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserId.Location = new System.Drawing.Point(198, 19);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(381, 35);
            this.textBoxUserId.TabIndex = 1;
            this.textBoxUserId.TextChanged += new System.EventHandler(this.textBoxUserId_TextChanged);
            this.textBoxUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserID_KeyPress);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(7, 22);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(105, 29);
            this.lblUserId.TabIndex = 32;
            this.lblUserId.Text = "User ID :";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(7, 259);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(76, 29);
            this.lblRole.TabIndex = 30;
            this.lblRole.Text = "Role :";
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(12, 410);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersWidth = 62;
            this.dataGridViewUser.RowTemplate.Height = 28;
            this.dataGridViewUser.Size = new System.Drawing.Size(954, 300);
            this.dataGridViewUser.TabIndex = 29;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(710, 210);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 49);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(836, 162);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 49);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(585, 162);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 49);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(710, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 49);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(198, 196);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(381, 35);
            this.textBoxPassword.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(198, 135);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(381, 35);
            this.textBoxEmail.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(7, 199);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(132, 29);
            this.lblPassword.TabIndex = 20;
            this.lblPassword.Text = "Password :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(7, 138);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 29);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(7, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 29);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Name :";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(198, 77);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(381, 35);
            this.textBoxName.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Sienna;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(836, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 49);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(198, 256);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(381, 37);
            this.comboBoxRole.TabIndex = 5;
            // 
            // 
            // lblStudentLink
            // 
            this.lblStudentLink.AutoSize = true;
            this.lblStudentLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentLink.Location = new System.Drawing.Point(7, 314);
            this.lblStudentLink.Name = "lblStudentLink";
            this.lblStudentLink.Size = new System.Drawing.Size(167, 29);
            this.lblStudentLink.TabIndex = 33;
            this.lblStudentLink.Text = "Student Link :";
            // 
            // comboBoxStudentLink
            // 
            this.comboBoxStudentLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudentLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStudentLink.FormattingEnabled = true;
            this.comboBoxStudentLink.Location = new System.Drawing.Point(198, 311);
            this.comboBoxStudentLink.Name = "comboBoxStudentLink";
            this.comboBoxStudentLink.Size = new System.Drawing.Size(381, 37);
            this.comboBoxStudentLink.TabIndex = 11;
            // 
            // lblLecturerLink
            // 
            this.lblLecturerLink.AutoSize = true;
            this.lblLecturerLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecturerLink.Location = new System.Drawing.Point(7, 359);
            this.lblLecturerLink.Name = "lblLecturerLink";
            this.lblLecturerLink.Size = new System.Drawing.Size(169, 29);
            this.lblLecturerLink.TabIndex = 34;
            this.lblLecturerLink.Text = "Lecturer Link :";
            // 
            // comboBoxLecturerLink
            // 
            this.comboBoxLecturerLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLecturerLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLecturerLink.FormattingEnabled = true;
            this.comboBoxLecturerLink.Location = new System.Drawing.Point(198, 356);
            this.comboBoxLecturerLink.Name = "comboBoxLecturerLink";
            this.comboBoxLecturerLink.Size = new System.Drawing.Size(381, 37);
            this.comboBoxLecturerLink.TabIndex = 12;
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(978, 730);
            this.Controls.Add(this.comboBoxLecturerLink);
            this.Controls.Add(this.lblLecturerLink);
            this.Controls.Add(this.comboBoxStudentLink);
            this.Controls.Add(this.lblStudentLink);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.dataGridViewUser);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.textBoxName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 790);
            this.MinimumSize = new System.Drawing.Size(1000, 790);
            this.Name = "UserPage";
            this.Text = "User";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label lblStudentLink;
        private System.Windows.Forms.ComboBox comboBoxStudentLink;
        private System.Windows.Forms.Label lblLecturerLink;
        private System.Windows.Forms.ComboBox comboBoxLecturerLink;
    }
}
