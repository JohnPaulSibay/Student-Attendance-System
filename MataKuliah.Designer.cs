namespace StudentAttendanceSystem
{
    partial class MataKuliah
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
            this.btnBack = new System.Windows.Forms.Button();
            this.textBoxMatKul = new System.Windows.Forms.TextBox();
            this.lblMatKul = new System.Windows.Forms.Label();
            this.dataGridViewMatKul = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDosenPengampu = new System.Windows.Forms.Label();
            this.lblMatKulName = new System.Windows.Forms.Label();
            this.textBoxMatKulName = new System.Windows.Forms.TextBox();
            this.comboBoxDosenPengampu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatKul)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Sienna;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(557, 8);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 32);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBoxMatKul
            // 
            this.textBoxMatKul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatKul.Location = new System.Drawing.Point(132, 12);
            this.textBoxMatKul.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMatKul.Name = "textBoxMatKul";
            this.textBoxMatKul.Size = new System.Drawing.Size(255, 26);
            this.textBoxMatKul.TabIndex = 1;
            // 
            // lblMatKul
            // 
            this.lblMatKul.AutoSize = true;
            this.lblMatKul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKul.Location = new System.Drawing.Point(5, 14);
            this.lblMatKul.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKul.Name = "lblMatKul";
            this.lblMatKul.Size = new System.Drawing.Size(110, 20);
            this.lblMatKul.TabIndex = 48;
            this.lblMatKul.Text = "Course Code :";
            // 
            // dataGridViewMatKul
            // 
            this.dataGridViewMatKul.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMatKul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatKul.Location = new System.Drawing.Point(8, 201);
            this.dataGridViewMatKul.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewMatKul.Name = "dataGridViewMatKul";
            this.dataGridViewMatKul.ReadOnly = true;
            this.dataGridViewMatKul.RowHeadersWidth = 62;
            this.dataGridViewMatKul.RowTemplate.Height = 28;
            this.dataGridViewMatKul.Size = new System.Drawing.Size(636, 210);
            this.dataGridViewMatKul.TabIndex = 45;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(473, 136);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 32);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(557, 105);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 32);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(390, 105);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 32);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(473, 74);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 32);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDosenPengampu
            // 
            this.lblDosenPengampu.AutoSize = true;
            this.lblDosenPengampu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosenPengampu.Location = new System.Drawing.Point(5, 90);
            this.lblDosenPengampu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDosenPengampu.Name = "lblDosenPengampu";
            this.lblDosenPengampu.Size = new System.Drawing.Size(76, 20);
            this.lblDosenPengampu.TabIndex = 37;
            this.lblDosenPengampu.Text = "Lecturer :";
            // 
            // lblMatKulName
            // 
            this.lblMatKulName.AutoSize = true;
            this.lblMatKulName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKulName.Location = new System.Drawing.Point(5, 52);
            this.lblMatKulName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKulName.Name = "lblMatKulName";
            this.lblMatKulName.Size = new System.Drawing.Size(114, 20);
            this.lblMatKulName.TabIndex = 36;
            this.lblMatKulName.Text = "Course Name :";
            // 
            // textBoxMatKulName
            // 
            this.textBoxMatKulName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatKulName.Location = new System.Drawing.Point(132, 50);
            this.textBoxMatKulName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMatKulName.Name = "textBoxMatKulName";
            this.textBoxMatKulName.Size = new System.Drawing.Size(255, 26);
            this.textBoxMatKulName.TabIndex = 2;
            // 
            // comboBoxDosenPengampu
            // 
            this.comboBoxDosenPengampu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDosenPengampu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDosenPengampu.FormattingEnabled = true;
            this.comboBoxDosenPengampu.Location = new System.Drawing.Point(132, 88);
            this.comboBoxDosenPengampu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxDosenPengampu.Name = "comboBoxDosenPengampu";
            this.comboBoxDosenPengampu.Size = new System.Drawing.Size(255, 28);
            this.comboBoxDosenPengampu.TabIndex = 3;
            // 
            // MataKuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(656, 430);
            this.Controls.Add(this.comboBoxDosenPengampu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBoxMatKul);
            this.Controls.Add(this.lblMatKul);
            this.Controls.Add(this.dataGridViewMatKul);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDosenPengampu);
            this.Controls.Add(this.lblMatKulName);
            this.Controls.Add(this.textBoxMatKulName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(672, 469);
            this.MinimumSize = new System.Drawing.Size(672, 469);
            this.Name = "MataKuliah";
            this.Text = "Course";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatKul)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBoxMatKul;
        private System.Windows.Forms.Label lblMatKul;
        private System.Windows.Forms.DataGridView dataGridViewMatKul;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblDosenPengampu;
        private System.Windows.Forms.Label lblMatKulName;
        private System.Windows.Forms.TextBox textBoxMatKulName;
        private System.Windows.Forms.ComboBox comboBoxDosenPengampu;
    }
}