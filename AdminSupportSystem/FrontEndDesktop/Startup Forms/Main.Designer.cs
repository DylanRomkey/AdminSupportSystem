namespace FrontEndDesktop
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreatePO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyPO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcessPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSearchEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModifyEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuApplySalary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGeneratePay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSickDay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsCreatePO = new System.Windows.Forms.ToolStripButton();
            this.tlsModifyPO = new System.Windows.Forms.ToolStripButton();
            this.tlsProcessPO = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsSearchEmployee = new System.Windows.Forms.ToolStripButton();
            this.tlsCreateEmployee = new System.Windows.Forms.ToolStripButton();
            this.tlsModifyEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsApplySalary = new System.Windows.Forms.ToolStripButton();
            this.tlsGeneratePay = new System.Windows.Forms.ToolStripButton();
            this.tlsSickDay = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuMaintenance,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuLogout,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = global::FrontEndDesktop.Properties.Resources.login1;
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(112, 22);
            this.mnuLogin.Text = "Login";
            this.mnuLogin.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Image = global::FrontEndDesktop.Properties.Resources.logout;
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(112, 22);
            this.mnuLogout.Text = "Logout";
            this.mnuLogout.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::FrontEndDesktop.Properties.Resources.exit1;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(112, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuMaintenance
            // 
            this.mnuMaintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreatePO,
            this.mnuModifyPO,
            this.mnuProcessPO,
            this.toolStripSeparator2,
            this.mnuSearchEmployee,
            this.mnuCreateEmployee,
            this.mnuModifyEmployee,
            this.toolStripSeparator3,
            this.mnuApplySalary,
            this.mnuGeneratePay,
            this.mnuSickDay});
            this.mnuMaintenance.Name = "mnuMaintenance";
            this.mnuMaintenance.Size = new System.Drawing.Size(88, 20);
            this.mnuMaintenance.Text = "Maintenance";
            this.mnuMaintenance.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuCreatePO
            // 
            this.mnuCreatePO.Image = global::FrontEndDesktop.Properties.Resources.createPurchaseOrder1;
            this.mnuCreatePO.Name = "mnuCreatePO";
            this.mnuCreatePO.Size = new System.Drawing.Size(198, 22);
            this.mnuCreatePO.Text = "Create Purchase Order";
            this.mnuCreatePO.ToolTipText = "Create Purchase Order";
            this.mnuCreatePO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuModifyPO
            // 
            this.mnuModifyPO.Image = global::FrontEndDesktop.Properties.Resources.modifyPurchaseOrder;
            this.mnuModifyPO.Name = "mnuModifyPO";
            this.mnuModifyPO.Size = new System.Drawing.Size(198, 22);
            this.mnuModifyPO.Text = "Modify Purchase Order";
            this.mnuModifyPO.ToolTipText = "Modify Purchase Order";
            this.mnuModifyPO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuProcessPO
            // 
            this.mnuProcessPO.Image = global::FrontEndDesktop.Properties.Resources.processPurchaseOrder;
            this.mnuProcessPO.Name = "mnuProcessPO";
            this.mnuProcessPO.Size = new System.Drawing.Size(198, 22);
            this.mnuProcessPO.Text = "Process Purchase Order";
            this.mnuProcessPO.ToolTipText = "Process Purchase Order";
            this.mnuProcessPO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuSearchEmployee
            // 
            this.mnuSearchEmployee.Image = global::FrontEndDesktop.Properties.Resources.searchEmployee;
            this.mnuSearchEmployee.Name = "mnuSearchEmployee";
            this.mnuSearchEmployee.Size = new System.Drawing.Size(198, 22);
            this.mnuSearchEmployee.Text = "Search Employee";
            this.mnuSearchEmployee.ToolTipText = "Search Employee";
            this.mnuSearchEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuCreateEmployee
            // 
            this.mnuCreateEmployee.Image = global::FrontEndDesktop.Properties.Resources.createEmployee;
            this.mnuCreateEmployee.Name = "mnuCreateEmployee";
            this.mnuCreateEmployee.Size = new System.Drawing.Size(198, 22);
            this.mnuCreateEmployee.Text = "Create Employee";
            this.mnuCreateEmployee.ToolTipText = "Create Employee";
            this.mnuCreateEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuModifyEmployee
            // 
            this.mnuModifyEmployee.Image = global::FrontEndDesktop.Properties.Resources.modifyEmployee;
            this.mnuModifyEmployee.Name = "mnuModifyEmployee";
            this.mnuModifyEmployee.Size = new System.Drawing.Size(198, 22);
            this.mnuModifyEmployee.Text = "Modify Employee";
            this.mnuModifyEmployee.ToolTipText = "Modify Employee";
            this.mnuModifyEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuApplySalary
            // 
            this.mnuApplySalary.Image = global::FrontEndDesktop.Properties.Resources.applySalary;
            this.mnuApplySalary.Name = "mnuApplySalary";
            this.mnuApplySalary.Size = new System.Drawing.Size(198, 22);
            this.mnuApplySalary.Text = "Apply Salary";
            this.mnuApplySalary.ToolTipText = "Apply Salary";
            this.mnuApplySalary.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuGeneratePay
            // 
            this.mnuGeneratePay.Image = global::FrontEndDesktop.Properties.Resources.generatePay;
            this.mnuGeneratePay.Name = "mnuGeneratePay";
            this.mnuGeneratePay.Size = new System.Drawing.Size(198, 22);
            this.mnuGeneratePay.Text = "Generate Pay";
            this.mnuGeneratePay.ToolTipText = "Generate Pay";
            this.mnuGeneratePay.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuSickDay
            // 
            this.mnuSickDay.Image = global::FrontEndDesktop.Properties.Resources.sickday;
            this.mnuSickDay.Name = "mnuSickDay";
            this.mnuSickDay.Size = new System.Drawing.Size(198, 22);
            this.mnuSickDay.Text = "Record Sickday";
            this.mnuSickDay.ToolTipText = "Record Sickday";
            this.mnuSickDay.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = global::FrontEndDesktop.Properties.Resources.about;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.ToolTipText = "About";
            this.mnuAbout.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsCreatePO,
            this.tlsModifyPO,
            this.tlsProcessPO,
            this.toolStripSeparator1,
            this.tlsSearchEmployee,
            this.tlsCreateEmployee,
            this.tlsModifyEmployee,
            this.toolStripSeparator4,
            this.tlsApplySalary,
            this.tlsGeneratePay,
            this.tlsSickDay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 37);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsCreatePO
            // 
            this.tlsCreatePO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsCreatePO.Image = global::FrontEndDesktop.Properties.Resources.createPurchaseOrder1;
            this.tlsCreatePO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsCreatePO.Margin = new System.Windows.Forms.Padding(7, 1, 0, 2);
            this.tlsCreatePO.Name = "tlsCreatePO";
            this.tlsCreatePO.Size = new System.Drawing.Size(34, 34);
            this.tlsCreatePO.Text = "toolStripButton1";
            this.tlsCreatePO.ToolTipText = "Create Purchase Order";
            this.tlsCreatePO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsModifyPO
            // 
            this.tlsModifyPO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsModifyPO.Image = global::FrontEndDesktop.Properties.Resources.modifyPurchaseOrder;
            this.tlsModifyPO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsModifyPO.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tlsModifyPO.Name = "tlsModifyPO";
            this.tlsModifyPO.Size = new System.Drawing.Size(34, 34);
            this.tlsModifyPO.Text = "toolStripButton1";
            this.tlsModifyPO.ToolTipText = "Modify Purchase Order";
            this.tlsModifyPO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsProcessPO
            // 
            this.tlsProcessPO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsProcessPO.Image = global::FrontEndDesktop.Properties.Resources.processPurchaseOrder;
            this.tlsProcessPO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsProcessPO.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tlsProcessPO.Name = "tlsProcessPO";
            this.tlsProcessPO.Size = new System.Drawing.Size(34, 34);
            this.tlsProcessPO.Text = "toolStripButton1";
            this.tlsProcessPO.ToolTipText = "Process Purchase Order";
            this.tlsProcessPO.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // tlsSearchEmployee
            // 
            this.tlsSearchEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsSearchEmployee.Image = global::FrontEndDesktop.Properties.Resources.searchEmployee;
            this.tlsSearchEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSearchEmployee.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tlsSearchEmployee.Name = "tlsSearchEmployee";
            this.tlsSearchEmployee.Size = new System.Drawing.Size(34, 34);
            this.tlsSearchEmployee.Text = "Search Employee";
            this.tlsSearchEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsCreateEmployee
            // 
            this.tlsCreateEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsCreateEmployee.Image = global::FrontEndDesktop.Properties.Resources.createEmployee;
            this.tlsCreateEmployee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tlsCreateEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsCreateEmployee.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tlsCreateEmployee.Name = "tlsCreateEmployee";
            this.tlsCreateEmployee.Size = new System.Drawing.Size(39, 34);
            this.tlsCreateEmployee.Text = "toolStripButton1";
            this.tlsCreateEmployee.ToolTipText = "Create Employee";
            this.tlsCreateEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsModifyEmployee
            // 
            this.tlsModifyEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsModifyEmployee.Image = global::FrontEndDesktop.Properties.Resources.modifyEmployee;
            this.tlsModifyEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsModifyEmployee.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tlsModifyEmployee.Name = "tlsModifyEmployee";
            this.tlsModifyEmployee.Size = new System.Drawing.Size(34, 34);
            this.tlsModifyEmployee.Text = "tlsModifyEmployee";
            this.tlsModifyEmployee.ToolTipText = "Modify Employee";
            this.tlsModifyEmployee.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 37);
            // 
            // tlsApplySalary
            // 
            this.tlsApplySalary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsApplySalary.Image = global::FrontEndDesktop.Properties.Resources.applySalary;
            this.tlsApplySalary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsApplySalary.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tlsApplySalary.Name = "tlsApplySalary";
            this.tlsApplySalary.Size = new System.Drawing.Size(34, 34);
            this.tlsApplySalary.Text = "toolStripButton1";
            this.tlsApplySalary.ToolTipText = "Apply Salary";
            this.tlsApplySalary.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsGeneratePay
            // 
            this.tlsGeneratePay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsGeneratePay.Image = global::FrontEndDesktop.Properties.Resources.generatePay;
            this.tlsGeneratePay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsGeneratePay.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tlsGeneratePay.Name = "tlsGeneratePay";
            this.tlsGeneratePay.Size = new System.Drawing.Size(34, 34);
            this.tlsGeneratePay.Text = "Generate Pay";
            this.tlsGeneratePay.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tlsSickDay
            // 
            this.tlsSickDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsSickDay.Image = global::FrontEndDesktop.Properties.Resources.sickday;
            this.tlsSickDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSickDay.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.tlsSickDay.Name = "tlsSickDay";
            this.tlsSickDay.Size = new System.Drawing.Size(34, 34);
            this.tlsSickDay.Text = "Record Sickday";
            this.tlsSickDay.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(8, 61);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(829, 577);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 641);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GearWorks Admin Support System";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsCreatePO;
        private MdiTabControl.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuMaintenance;
        private System.Windows.Forms.ToolStripMenuItem mnuCreatePO;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyPO;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripButton tlsModifyPO;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton tlsProcessPO;
        private System.Windows.Forms.ToolStripButton tlsCreateEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuProcessPO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateEmployee;
        private System.Windows.Forms.ToolStripButton tlsSearchEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuSearchEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuApplySalary;
        private System.Windows.Forms.ToolStripButton tlsApplySalary;
        private System.Windows.Forms.ToolStripMenuItem mnuGeneratePay;
        private System.Windows.Forms.ToolStripButton tlsGeneratePay;
        private System.Windows.Forms.ToolStripButton tlsModifyEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuModifyEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlsSickDay;
        private System.Windows.Forms.ToolStripMenuItem mnuSickDay;
        internal System.Windows.Forms.Timer timer1;
    }
}