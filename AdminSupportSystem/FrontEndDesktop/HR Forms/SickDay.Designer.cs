namespace FrontEndDesktop.HR_Forms
{
    partial class SickDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SickDay));
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtMinit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlSick = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkFullday = new System.Windows.Forms.CheckBox();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.dtpSickdayStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSickdayEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.pnlSick.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.txtFname);
            this.pnlInfo.Controls.Add(this.label8);
            this.pnlInfo.Controls.Add(this.btnSearch);
            this.pnlInfo.Controls.Add(this.txtPC);
            this.pnlInfo.Controls.Add(this.txtStreet);
            this.pnlInfo.Controls.Add(this.txtMinit);
            this.pnlInfo.Controls.Add(this.label7);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.txtCity);
            this.pnlInfo.Controls.Add(this.dtpDob);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.label9);
            this.pnlInfo.Controls.Add(this.txtLname);
            this.pnlInfo.Controls.Add(this.label10);
            this.pnlInfo.Location = new System.Drawing.Point(137, 90);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(218, 359);
            this.pnlInfo.TabIndex = 27;
            // 
            // txtFname
            // 
            this.txtFname.Enabled = false;
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(71, 317);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPC
            // 
            this.txtPC.Enabled = false;
            this.txtPC.Location = new System.Drawing.Point(12, 286);
            this.txtPC.MaxLength = 6;
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(196, 20);
            this.txtPC.TabIndex = 6;
            // 
            // txtStreet
            // 
            this.txtStreet.Enabled = false;
            this.txtStreet.Location = new System.Drawing.Point(12, 235);
            this.txtStreet.MaxLength = 100;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(196, 20);
            this.txtStreet.TabIndex = 5;
            // 
            // txtMinit
            // 
            this.txtMinit.Enabled = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Middle initial: ";
            // 
            // txtCity
            // 
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point(12, 189);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(196, 20);
            this.txtCity.TabIndex = 4;
            // 
            // dtpDob
            // 
            this.dtpDob.Enabled = false;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(88, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Date of birth:";
            // 
            // txtLname
            // 
            this.txtLname.Enabled = false;
            this.txtLname.Location = new System.Drawing.Point(12, 87);
            this.txtLname.MaxLength = 50;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(196, 20);
            this.txtLname.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Last name:";
            // 
            // pnlSick
            // 
            this.pnlSick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSick.Controls.Add(this.btnClear);
            this.pnlSick.Controls.Add(this.btnSave);
            this.pnlSick.Controls.Add(this.chkFullday);
            this.pnlSick.Controls.Add(this.chkMulti);
            this.pnlSick.Controls.Add(this.dtpSickdayStart);
            this.pnlSick.Controls.Add(this.label3);
            this.pnlSick.Controls.Add(this.dtpSickdayEnd);
            this.pnlSick.Controls.Add(this.label2);
            this.pnlSick.Controls.Add(this.txtDescription);
            this.pnlSick.Controls.Add(this.label1);
            this.pnlSick.Enabled = false;
            this.pnlSick.Location = new System.Drawing.Point(413, 145);
            this.pnlSick.Name = "pnlSick";
            this.pnlSick.Size = new System.Drawing.Size(263, 248);
            this.pnlSick.TabIndex = 26;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(133, 213);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(52, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkFullday
            // 
            this.chkFullday.AutoSize = true;
            this.chkFullday.Location = new System.Drawing.Point(19, 12);
            this.chkFullday.Name = "chkFullday";
            this.chkFullday.Size = new System.Drawing.Size(62, 17);
            this.chkFullday.TabIndex = 0;
            this.chkFullday.Text = "Full day";
            this.chkFullday.UseVisualStyleBackColor = true;
            // 
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(87, 12);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(65, 17);
            this.chkMulti.TabIndex = 1;
            this.chkMulti.Text = "Multiday";
            this.chkMulti.UseVisualStyleBackColor = true;
            this.chkMulti.CheckedChanged += new System.EventHandler(this.chkMulti_CheckedChanged);
            // 
            // dtpSickdayStart
            // 
            this.dtpSickdayStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSickdayStart.Location = new System.Drawing.Point(54, 41);
            this.dtpSickdayStart.Name = "dtpSickdayStart";
            this.dtpSickdayStart.Size = new System.Drawing.Size(102, 20);
            this.dtpSickdayStart.TabIndex = 2;
            this.dtpSickdayStart.ValueChanged += new System.EventHandler(this.dtpSickdayStart_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "End:";
            // 
            // dtpSickdayEnd
            // 
            this.dtpSickdayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSickdayEnd.Location = new System.Drawing.Point(54, 67);
            this.dtpSickdayEnd.Name = "dtpSickdayEnd";
            this.dtpSickdayEnd.Size = new System.Drawing.Size(102, 20);
            this.dtpSickdayEnd.TabIndex = 3;
            this.dtpSickdayEnd.ValueChanged += new System.EventHandler(this.dtpSickdayEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Start:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(19, 119);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(221, 81);
            this.txtDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Description:";
            // 
            // SickDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlSick);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SickDay";
            this.Text = "Sick Day";
            this.Load += new System.EventHandler(this.SickDay_Load);
            this.Enter += new System.EventHandler(this.SickDay_Enter);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlSick.ResumeLayout(false);
            this.pnlSick.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtMinit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlSick;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkFullday;
        private System.Windows.Forms.CheckBox chkMulti;
        private System.Windows.Forms.DateTimePicker dtpSickdayStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSickdayEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
    }
}