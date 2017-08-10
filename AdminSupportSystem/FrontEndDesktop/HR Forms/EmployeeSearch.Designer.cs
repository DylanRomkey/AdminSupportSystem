namespace FrontEndDesktop.HR_Forms
{
    partial class EmployeeSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSearch));
            this.btnMod = new System.Windows.Forms.Button();
            this.btnSick = new System.Windows.Forms.Button();
            this.btnRaise = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtMinit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstEmps = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLname = new System.Windows.Forms.RadioButton();
            this.rdoId = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(452, 487);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(75, 23);
            this.btnMod.TabIndex = 5;
            this.btnMod.Text = "Modify";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSick
            // 
            this.btnSick.Enabled = false;
            this.btnSick.Location = new System.Drawing.Point(369, 487);
            this.btnSick.Name = "btnSick";
            this.btnSick.Size = new System.Drawing.Size(75, 23);
            this.btnSick.TabIndex = 4;
            this.btnSick.Text = "Sick";
            this.btnSick.UseVisualStyleBackColor = true;
            this.btnSick.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRaise
            // 
            this.btnRaise.Enabled = false;
            this.btnRaise.Location = new System.Drawing.Point(286, 487);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(75, 23);
            this.btnRaise.TabIndex = 3;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = true;
            this.btnRaise.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pnlInfo);
            this.panel1.Location = new System.Drawing.Point(220, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 345);
            this.panel1.TabIndex = 21;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.txtFname);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.txtPC);
            this.pnlInfo.Controls.Add(this.txtStreet);
            this.pnlInfo.Controls.Add(this.txtMinit);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.txtCity);
            this.pnlInfo.Controls.Add(this.dtpDob);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.txtLname);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Location = new System.Drawing.Point(4, 4);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(218, 334);
            this.pnlInfo.TabIndex = 0;
            this.pnlInfo.Visible = false;
            // 
            // txtFname
            // 
            this.txtFname.Enabled = false;
            this.txtFname.Location = new System.Drawing.Point(12, 37);
            this.txtFname.MaxLength = 50;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(196, 20);
            this.txtFname.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "First name:";
            // 
            // txtPC
            // 
            this.txtPC.Enabled = false;
            this.txtPC.Location = new System.Drawing.Point(12, 286);
            this.txtPC.MaxLength = 6;
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(196, 20);
            this.txtPC.TabIndex = 19;
            // 
            // txtStreet
            // 
            this.txtStreet.Enabled = false;
            this.txtStreet.Location = new System.Drawing.Point(12, 235);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(196, 20);
            this.txtStreet.TabIndex = 17;
            // 
            // txtMinit
            // 
            this.txtMinit.Enabled = false;
            this.txtMinit.Location = new System.Drawing.Point(12, 138);
            this.txtMinit.MaxLength = 1;
            this.txtMinit.Name = "txtMinit";
            this.txtMinit.Size = new System.Drawing.Size(55, 20);
            this.txtMinit.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Postal code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Street:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Middle initial: ";
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(12, 189);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(196, 20);
            this.txtCity.TabIndex = 11;
            // 
            // dtpDob
            // 
            this.dtpDob.Enabled = false;
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(91, 138);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(117, 20);
            this.dtpDob.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date of birth:";
            // 
            // txtLname
            // 
            this.txtLname.Enabled = false;
            this.txtLname.Location = new System.Drawing.Point(12, 87);
            this.txtLname.MaxLength = 50;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(196, 20);
            this.txtLname.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Last name:";
            // 
            // lstEmps
            // 
            this.lstEmps.FormattingEnabled = true;
            this.lstEmps.Location = new System.Drawing.Point(454, 130);
            this.lstEmps.Name = "lstEmps";
            this.lstEmps.Size = new System.Drawing.Size(139, 342);
            this.lstEmps.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoLname);
            this.groupBox1.Controls.Add(this.rdoId);
            this.groupBox1.Location = new System.Drawing.Point(419, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 70);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search by:";
            // 
            // rdoLname
            // 
            this.rdoLname.AutoSize = true;
            this.rdoLname.Location = new System.Drawing.Point(7, 43);
            this.rdoLname.Name = "rdoLname";
            this.rdoLname.Size = new System.Drawing.Size(74, 17);
            this.rdoLname.TabIndex = 1;
            this.rdoLname.TabStop = true;
            this.rdoLname.Text = "Last name";
            this.rdoLname.UseVisualStyleBackColor = true;
            // 
            // rdoId
            // 
            this.rdoId.AutoSize = true;
            this.rdoId.Location = new System.Drawing.Point(7, 20);
            this.rdoId.Name = "rdoId";
            this.rdoId.Size = new System.Drawing.Size(82, 17);
            this.rdoId.TabIndex = 0;
            this.rdoId.TabStop = true;
            this.rdoId.Text = "Employee id";
            this.rdoId.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(314, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(294, 50);
            this.txtInfo.MaxLength = 50;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(112, 20);
            this.txtInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Enter an employee\'s info:";
            // 
            // EmployeeSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnSick);
            this.Controls.Add(this.btnRaise);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstEmps);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeSearch";
            this.Text = "Search Employees";
            this.Load += new System.EventHandler(this.EmployeeSearch_Load);
            this.panel1.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btnSick;
        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtMinit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstEmps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLname;
        private System.Windows.Forms.RadioButton rdoId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label1;
    }
}