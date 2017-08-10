namespace FrontEndDesktop.HR_Forms
{
    partial class EmployeeModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeModification));
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSections = new System.Windows.Forms.ComboBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.dtpAffDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.txtSen = new System.Windows.Forms.TextBox();
            this.lable = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSIN2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlPer = new System.Windows.Forms.Panel();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlJob = new System.Windows.Forms.Panel();
            this.txtSup = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPayrate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ddlDepartments = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlJobs = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpJobStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSIN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlStatus.SuspendLayout();
            this.pnlPer.SuspendLayout();
            this.pnlJob.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Choose a section to modify:";
            // 
            // ddlSections
            // 
            this.ddlSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSections.FormattingEnabled = true;
            this.ddlSections.Location = new System.Drawing.Point(335, 54);
            this.ddlSections.Name = "ddlSections";
            this.ddlSections.Size = new System.Drawing.Size(142, 21);
            this.ddlSections.TabIndex = 0;
            this.ddlSections.SelectedIndexChanged += new System.EventHandler(this.ddlSections_SelectedIndexChanged);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatus.Controls.Add(this.dtpAffDate);
            this.pnlStatus.Controls.Add(this.label17);
            this.pnlStatus.Controls.Add(this.ddlStatus);
            this.pnlStatus.Controls.Add(this.txtSen);
            this.pnlStatus.Controls.Add(this.lable);
            this.pnlStatus.Controls.Add(this.label13);
            this.pnlStatus.Controls.Add(this.txtSIN2);
            this.pnlStatus.Controls.Add(this.label12);
            this.pnlStatus.Enabled = false;
            this.pnlStatus.Location = new System.Drawing.Point(572, 104);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(218, 334);
            this.pnlStatus.TabIndex = 30;
            // 
            // dtpAffDate
            // 
            this.dtpAffDate.Location = new System.Drawing.Point(10, 248);
            this.dtpAffDate.Name = "dtpAffDate";
            this.dtpAffDate.Size = new System.Drawing.Size(196, 20);
            this.dtpAffDate.TabIndex = 2;
            this.dtpAffDate.ValueChanged += new System.EventHandler(this.dtpAffDate_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Affective date:";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(10, 190);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(196, 21);
            this.ddlStatus.TabIndex = 1;
            this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
            // 
            // txtSen
            // 
            this.txtSen.Location = new System.Drawing.Point(10, 135);
            this.txtSen.MaxLength = 9;
            this.txtSen.Name = "txtSen";
            this.txtSen.ReadOnly = true;
            this.txtSen.Size = new System.Drawing.Size(196, 20);
            this.txtSen.TabIndex = 18;
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(10, 174);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(40, 13);
            this.lable.TabIndex = 33;
            this.lable.Text = "Status:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Seniority date :";
            // 
            // txtSIN2
            // 
            this.txtSIN2.Location = new System.Drawing.Point(10, 80);
            this.txtSIN2.MaxLength = 9;
            this.txtSIN2.Name = "txtSIN2";
            this.txtSIN2.ReadOnly = true;
            this.txtSIN2.Size = new System.Drawing.Size(196, 20);
            this.txtSIN2.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "SIN:";
            // 
            // pnlPer
            // 
            this.pnlPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPer.Controls.Add(this.txtFname);
            this.pnlPer.Controls.Add(this.label8);
            this.pnlPer.Controls.Add(this.txtPC);
            this.pnlPer.Controls.Add(this.txtStreet);
            this.pnlPer.Controls.Add(this.txtMinit);
            this.pnlPer.Controls.Add(this.label7);
            this.pnlPer.Controls.Add(this.label5);
            this.pnlPer.Controls.Add(this.label3);
            this.pnlPer.Controls.Add(this.txtCity);
            this.pnlPer.Controls.Add(this.dtpDob);
            this.pnlPer.Controls.Add(this.label6);
            this.pnlPer.Controls.Add(this.label4);
            this.pnlPer.Controls.Add(this.txtLname);
            this.pnlPer.Controls.Add(this.label2);
            this.pnlPer.Enabled = false;
            this.pnlPer.Location = new System.Drawing.Point(22, 104);
            this.pnlPer.Name = "pnlPer";
            this.pnlPer.Size = new System.Drawing.Size(218, 334);
            this.pnlPer.TabIndex = 0;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(12, 37);
            this.txtFname.MaxLength = 50;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(196, 20);
            this.txtFname.TabIndex = 0;
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
            this.txtPC.Location = new System.Drawing.Point(12, 286);
            this.txtPC.MaxLength = 6;
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(196, 20);
            this.txtPC.TabIndex = 6;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(12, 235);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(196, 20);
            this.txtStreet.TabIndex = 5;
            // 
            // txtMinit
            // 
            this.txtMinit.Location = new System.Drawing.Point(12, 138);
            this.txtMinit.MaxLength = 1;
            this.txtMinit.Name = "txtMinit";
            this.txtMinit.Size = new System.Drawing.Size(55, 20);
            this.txtMinit.TabIndex = 2;
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
            this.txtCity.Location = new System.Drawing.Point(12, 189);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(196, 20);
            this.txtCity.TabIndex = 4;
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(91, 138);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(117, 20);
            this.dtpDob.TabIndex = 3;
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
            this.txtLname.Location = new System.Drawing.Point(12, 87);
            this.txtLname.MaxLength = 50;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(196, 20);
            this.txtLname.TabIndex = 1;
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(410, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlJob
            // 
            this.pnlJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJob.Controls.Add(this.txtSup);
            this.pnlJob.Controls.Add(this.label16);
            this.pnlJob.Controls.Add(this.txtPayrate);
            this.pnlJob.Controls.Add(this.label15);
            this.pnlJob.Controls.Add(this.ddlDepartments);
            this.pnlJob.Controls.Add(this.label11);
            this.pnlJob.Controls.Add(this.ddlJobs);
            this.pnlJob.Controls.Add(this.label14);
            this.pnlJob.Controls.Add(this.dtpJobStart);
            this.pnlJob.Controls.Add(this.label10);
            this.pnlJob.Controls.Add(this.txtSIN);
            this.pnlJob.Controls.Add(this.label9);
            this.pnlJob.Enabled = false;
            this.pnlJob.Location = new System.Drawing.Point(297, 104);
            this.pnlJob.Name = "pnlJob";
            this.pnlJob.Size = new System.Drawing.Size(218, 334);
            this.pnlJob.TabIndex = 28;
            // 
            // txtSup
            // 
            this.txtSup.Location = new System.Drawing.Point(10, 235);
            this.txtSup.MaxLength = 9;
            this.txtSup.Name = "txtSup";
            this.txtSup.ReadOnly = true;
            this.txtSup.Size = new System.Drawing.Size(196, 20);
            this.txtSup.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 219);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Supervisor:";
            // 
            // txtPayrate
            // 
            this.txtPayrate.Location = new System.Drawing.Point(10, 286);
            this.txtPayrate.MaxLength = 50;
            this.txtPayrate.Name = "txtPayrate";
            this.txtPayrate.Size = new System.Drawing.Size(196, 20);
            this.txtPayrate.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 270);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Pay rate:";
            // 
            // ddlDepartments
            // 
            this.ddlDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDepartments.FormattingEnabled = true;
            this.ddlDepartments.Location = new System.Drawing.Point(10, 188);
            this.ddlDepartments.Name = "ddlDepartments";
            this.ddlDepartments.Size = new System.Drawing.Size(196, 21);
            this.ddlDepartments.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Department:";
            // 
            // ddlJobs
            // 
            this.ddlJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlJobs.FormattingEnabled = true;
            this.ddlJobs.Location = new System.Drawing.Point(10, 137);
            this.ddlJobs.Name = "ddlJobs";
            this.ddlJobs.Size = new System.Drawing.Size(196, 21);
            this.ddlJobs.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Job assinged:";
            // 
            // dtpJobStart
            // 
            this.dtpJobStart.Location = new System.Drawing.Point(10, 84);
            this.dtpJobStart.Name = "dtpJobStart";
            this.dtpJobStart.Size = new System.Drawing.Size(196, 20);
            this.dtpJobStart.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Job start date:";
            // 
            // txtSIN
            // 
            this.txtSIN.Location = new System.Drawing.Point(10, 37);
            this.txtSIN.MaxLength = 9;
            this.txtSIN.Name = "txtSIN";
            this.txtSIN.ReadOnly = true;
            this.txtSIN.Size = new System.Drawing.Size(196, 20);
            this.txtSIN.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "SIN:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(329, 478);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EmployeeModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlSections);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlPer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlJob);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeModification";
            this.Text = "Employee Modification";
            this.Load += new System.EventHandler(this.EmployeeModification_Load);
            this.Enter += new System.EventHandler(this.EmployeeModification_Enter);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlPer.ResumeLayout(false);
            this.pnlPer.PerformLayout();
            this.pnlJob.ResumeLayout(false);
            this.pnlJob.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSections;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.DateTimePicker dtpAffDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.TextBox txtSen;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSIN2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnlPer;
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlJob;
        private System.Windows.Forms.TextBox txtSup;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPayrate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ddlDepartments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlJobs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpJobStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSIN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
    }
}