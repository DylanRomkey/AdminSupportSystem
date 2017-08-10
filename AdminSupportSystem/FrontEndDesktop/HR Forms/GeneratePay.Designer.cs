namespace FrontEndDesktop.HR_Forms
{
    partial class GeneratePay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratePay));
            this.grbYTD = new System.Windows.Forms.GroupBox();
            this.txtYTDGross = new System.Windows.Forms.TextBox();
            this.txtYTDNet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtYTDPension = new System.Windows.Forms.TextBox();
            this.txtYTDTax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtYTDEI = new System.Windows.Forms.TextBox();
            this.txtYTDCPP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.grbThisPay = new System.Windows.Forms.GroupBox();
            this.txtGross = new System.Windows.Forms.TextBox();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPension = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEi = new System.Windows.Forms.TextBox();
            this.txtCPP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPayrate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayStubs = new System.Windows.Forms.DataGridView();
            this.grbYTD.SuspendLayout();
            this.grbThisPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayStubs)).BeginInit();
            this.SuspendLayout();
            // 
            // grbYTD
            // 
            this.grbYTD.Controls.Add(this.txtYTDGross);
            this.grbYTD.Controls.Add(this.txtYTDNet);
            this.grbYTD.Controls.Add(this.label12);
            this.grbYTD.Controls.Add(this.label13);
            this.grbYTD.Controls.Add(this.label14);
            this.grbYTD.Controls.Add(this.txtYTDPension);
            this.grbYTD.Controls.Add(this.txtYTDTax);
            this.grbYTD.Controls.Add(this.label15);
            this.grbYTD.Controls.Add(this.label16);
            this.grbYTD.Controls.Add(this.txtYTDEI);
            this.grbYTD.Controls.Add(this.txtYTDCPP);
            this.grbYTD.Controls.Add(this.label17);
            this.grbYTD.Location = new System.Drawing.Point(403, 430);
            this.grbYTD.Name = "grbYTD";
            this.grbYTD.Size = new System.Drawing.Size(368, 91);
            this.grbYTD.TabIndex = 58;
            this.grbYTD.TabStop = false;
            this.grbYTD.Text = "Year-to-date totals";
            // 
            // txtYTDGross
            // 
            this.txtYTDGross.Location = new System.Drawing.Point(16, 49);
            this.txtYTDGross.Name = "txtYTDGross";
            this.txtYTDGross.ReadOnly = true;
            this.txtYTDGross.Size = new System.Drawing.Size(56, 20);
            this.txtYTDGross.TabIndex = 33;
            this.txtYTDGross.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtYTDNet
            // 
            this.txtYTDNet.Location = new System.Drawing.Point(301, 49);
            this.txtYTDNet.Name = "txtYTDNet";
            this.txtYTDNet.ReadOnly = true;
            this.txtYTDNet.Size = new System.Drawing.Size(56, 20);
            this.txtYTDNet.TabIndex = 43;
            this.txtYTDNet.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Gross";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(298, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Net";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(70, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Tax";
            // 
            // txtYTDPension
            // 
            this.txtYTDPension.Location = new System.Drawing.Point(244, 49);
            this.txtYTDPension.Name = "txtYTDPension";
            this.txtYTDPension.ReadOnly = true;
            this.txtYTDPension.Size = new System.Drawing.Size(56, 20);
            this.txtYTDPension.TabIndex = 41;
            this.txtYTDPension.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtYTDTax
            // 
            this.txtYTDTax.Location = new System.Drawing.Point(73, 49);
            this.txtYTDTax.Name = "txtYTDTax";
            this.txtYTDTax.ReadOnly = true;
            this.txtYTDTax.Size = new System.Drawing.Size(56, 20);
            this.txtYTDTax.TabIndex = 35;
            this.txtYTDTax.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(244, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 40;
            this.label15.Text = "Pension";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(127, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "CPP";
            // 
            // txtYTDEI
            // 
            this.txtYTDEI.Location = new System.Drawing.Point(187, 49);
            this.txtYTDEI.Name = "txtYTDEI";
            this.txtYTDEI.ReadOnly = true;
            this.txtYTDEI.Size = new System.Drawing.Size(56, 20);
            this.txtYTDEI.TabIndex = 39;
            this.txtYTDEI.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtYTDCPP
            // 
            this.txtYTDCPP.Location = new System.Drawing.Point(130, 49);
            this.txtYTDCPP.Name = "txtYTDCPP";
            this.txtYTDCPP.ReadOnly = true;
            this.txtYTDCPP.Size = new System.Drawing.Size(56, 20);
            this.txtYTDCPP.TabIndex = 37;
            this.txtYTDCPP.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(190, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "EI";
            // 
            // grbThisPay
            // 
            this.grbThisPay.Controls.Add(this.txtGross);
            this.grbThisPay.Controls.Add(this.txtNet);
            this.grbThisPay.Controls.Add(this.label6);
            this.grbThisPay.Controls.Add(this.label11);
            this.grbThisPay.Controls.Add(this.label7);
            this.grbThisPay.Controls.Add(this.txtPension);
            this.grbThisPay.Controls.Add(this.txtTax);
            this.grbThisPay.Controls.Add(this.label10);
            this.grbThisPay.Controls.Add(this.label8);
            this.grbThisPay.Controls.Add(this.txtEi);
            this.grbThisPay.Controls.Add(this.txtCPP);
            this.grbThisPay.Controls.Add(this.label9);
            this.grbThisPay.Location = new System.Drawing.Point(41, 430);
            this.grbThisPay.Name = "grbThisPay";
            this.grbThisPay.Size = new System.Drawing.Size(356, 91);
            this.grbThisPay.TabIndex = 57;
            this.grbThisPay.TabStop = false;
            this.grbThisPay.Text = "This pay\'s totals";
            // 
            // txtGross
            // 
            this.txtGross.Location = new System.Drawing.Point(16, 49);
            this.txtGross.Name = "txtGross";
            this.txtGross.ReadOnly = true;
            this.txtGross.Size = new System.Drawing.Size(50, 20);
            this.txtGross.TabIndex = 33;
            this.txtGross.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtNet
            // 
            this.txtNet.Location = new System.Drawing.Point(296, 49);
            this.txtNet.Name = "txtNet";
            this.txtNet.ReadOnly = true;
            this.txtNet.Size = new System.Drawing.Size(50, 20);
            this.txtNet.TabIndex = 43;
            this.txtNet.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Gross";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Net";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Tax";
            // 
            // txtPension
            // 
            this.txtPension.Location = new System.Drawing.Point(240, 49);
            this.txtPension.Name = "txtPension";
            this.txtPension.ReadOnly = true;
            this.txtPension.Size = new System.Drawing.Size(50, 20);
            this.txtPension.TabIndex = 41;
            this.txtPension.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(72, 49);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(50, 20);
            this.txtTax.TabIndex = 35;
            this.txtTax.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Pension";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "CPP";
            // 
            // txtEi
            // 
            this.txtEi.Location = new System.Drawing.Point(184, 49);
            this.txtEi.Name = "txtEi";
            this.txtEi.ReadOnly = true;
            this.txtEi.Size = new System.Drawing.Size(50, 20);
            this.txtEi.TabIndex = 39;
            this.txtEi.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // txtCPP
            // 
            this.txtCPP.Location = new System.Drawing.Point(128, 49);
            this.txtCPP.Name = "txtCPP";
            this.txtCPP.ReadOnly = true;
            this.txtCPP.Size = new System.Drawing.Size(50, 20);
            this.txtCPP.TabIndex = 37;
            this.txtCPP.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "EI";
            // 
            // txtPayrate
            // 
            this.txtPayrate.Location = new System.Drawing.Point(655, 393);
            this.txtPayrate.Name = "txtPayrate";
            this.txtPayrate.ReadOnly = true;
            this.txtPayrate.Size = new System.Drawing.Size(68, 20);
            this.txtPayrate.TabIndex = 56;
            this.txtPayrate.BindingContextChanged += new System.EventHandler(this.txtFormat);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Payrate";
            // 
            // txtDob
            // 
            this.txtDob.Location = new System.Drawing.Point(351, 393);
            this.txtDob.Name = "txtDob";
            this.txtDob.ReadOnly = true;
            this.txtDob.Size = new System.Drawing.Size(101, 20);
            this.txtDob.TabIndex = 54;
            this.txtDob.BindingContextChanged += new System.EventHandler(this.dateFormat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Birthday";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(458, 393);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(190, 20);
            this.txtAddress.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Address";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(93, 393);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(121, 20);
            this.txtId.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "ID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(221, 393);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(124, 20);
            this.txtName.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Name";
            // 
            // dgvPayStubs
            // 
            this.dgvPayStubs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayStubs.Location = new System.Drawing.Point(12, 18);
            this.dgvPayStubs.Name = "dgvPayStubs";
            this.dgvPayStubs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayStubs.Size = new System.Drawing.Size(789, 347);
            this.dgvPayStubs.TabIndex = 46;
            // 
            // GeneratePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.grbYTD);
            this.Controls.Add(this.grbThisPay);
            this.Controls.Add(this.txtPayrate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPayStubs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneratePay";
            this.Text = "Generate Pay";
            this.Load += new System.EventHandler(this.GeneratePay_Load);
            this.grbYTD.ResumeLayout(false);
            this.grbYTD.PerformLayout();
            this.grbThisPay.ResumeLayout(false);
            this.grbThisPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayStubs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbYTD;
        private System.Windows.Forms.TextBox txtYTDGross;
        private System.Windows.Forms.TextBox txtYTDNet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtYTDPension;
        private System.Windows.Forms.TextBox txtYTDTax;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtYTDEI;
        private System.Windows.Forms.TextBox txtYTDCPP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox grbThisPay;
        private System.Windows.Forms.TextBox txtGross;
        private System.Windows.Forms.TextBox txtNet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPension;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEi;
        private System.Windows.Forms.TextBox txtCPP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPayrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPayStubs;
    }
}