namespace FrontEndDesktop
{
    partial class ProcessPurchaseOrder
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.grpSearchOther = new System.Windows.Forms.GroupBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoClosed = new System.Windows.Forms.RadioButton();
            this.rdoPending = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearchDates = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseOrders = new System.Windows.Forms.Label();
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtTaxes = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTaxes = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnCancelItems = new System.Windows.Forms.Button();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.txtDeny = new System.Windows.Forms.TextBox();
            this.lblDeny = new System.Windows.Forms.Label();
            this.pnlDeny = new System.Windows.Forms.Panel();
            this.btnCancelDeny = new System.Windows.Forms.Button();
            this.btnDenyFinal = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSearchOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlDeny.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(764, 41);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(21, 20);
            this.txtFilter.TabIndex = 14;
            // 
            // grpSearchOther
            // 
            this.grpSearchOther.Controls.Add(this.lblEmployeeName);
            this.grpSearchOther.Controls.Add(this.txtEmployeeName);
            this.grpSearchOther.Controls.Add(this.rdoAll);
            this.grpSearchOther.Controls.Add(this.rdoClosed);
            this.grpSearchOther.Controls.Add(this.rdoPending);
            this.grpSearchOther.Controls.Add(this.btnReset);
            this.grpSearchOther.Controls.Add(this.btnSearchDates);
            this.grpSearchOther.Controls.Add(this.lblEndDate);
            this.grpSearchOther.Controls.Add(this.lblStartDate);
            this.grpSearchOther.Controls.Add(this.dtpEndDate);
            this.grpSearchOther.Controls.Add(this.dtpStartDate);
            this.grpSearchOther.Location = new System.Drawing.Point(55, 13);
            this.grpSearchOther.Name = "grpSearchOther";
            this.grpSearchOther.Size = new System.Drawing.Size(703, 71);
            this.grpSearchOther.TabIndex = 0;
            this.grpSearchOther.TabStop = false;
            this.grpSearchOther.Text = "Search Purchase Orders";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(460, 18);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 10;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(406, 39);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(193, 20);
            this.txtEmployeeName.TabIndex = 7;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(325, 13);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 4;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoClosed
            // 
            this.rdoClosed.AutoSize = true;
            this.rdoClosed.Location = new System.Drawing.Point(325, 48);
            this.rdoClosed.Name = "rdoClosed";
            this.rdoClosed.Size = new System.Drawing.Size(57, 17);
            this.rdoClosed.TabIndex = 6;
            this.rdoClosed.TabStop = true;
            this.rdoClosed.Text = "Closed";
            this.rdoClosed.UseVisualStyleBackColor = true;
            this.rdoClosed.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoPending
            // 
            this.rdoPending.AutoSize = true;
            this.rdoPending.Location = new System.Drawing.Point(325, 31);
            this.rdoPending.Name = "rdoPending";
            this.rdoPending.Size = new System.Drawing.Size(64, 17);
            this.rdoPending.TabIndex = 5;
            this.rdoPending.TabStop = true;
            this.rdoPending.Text = "Pending";
            this.rdoPending.UseVisualStyleBackColor = true;
            this.rdoPending.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(618, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Rese&t";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearchDates
            // 
            this.btnSearchDates.Location = new System.Drawing.Point(618, 13);
            this.btnSearchDates.Name = "btnSearchDates";
            this.btnSearchDates.Size = new System.Drawing.Size(64, 23);
            this.btnSearchDates.TabIndex = 8;
            this.btnSearchDates.Text = "S&earch";
            this.btnSearchDates.UseVisualStyleBackColor = true;
            this.btnSearchDates.Click += new System.EventHandler(this.btnSearchDates_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(191, 20);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(63, 19);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(159, 36);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(122, 20);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(29, 36);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(122, 20);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblPurchaseOrders
            // 
            this.lblPurchaseOrders.AutoSize = true;
            this.lblPurchaseOrders.Location = new System.Drawing.Point(664, 111);
            this.lblPurchaseOrders.Name = "lblPurchaseOrders";
            this.lblPurchaseOrders.Size = new System.Drawing.Size(86, 13);
            this.lblPurchaseOrders.TabIndex = 2;
            this.lblPurchaseOrders.Text = "Purchase Orders";
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Location = new System.Drawing.Point(655, 165);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(104, 23);
            this.btnCancelSearch.TabIndex = 4;
            this.btnCancelSearch.Text = "&Cancel Search";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(655, 136);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select &Agreement";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(174, 100);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(465, 101);
            this.dgvOrders.TabIndex = 1;
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.txtStatus);
            this.grpOrder.Controls.Add(this.lblPONumber);
            this.grpOrder.Controls.Add(this.txtEmployee);
            this.grpOrder.Controls.Add(this.txtPONumber);
            this.grpOrder.Controls.Add(this.lblStatus);
            this.grpOrder.Controls.Add(this.txtTaxes);
            this.grpOrder.Controls.Add(this.lblSubtotal);
            this.grpOrder.Controls.Add(this.lblTaxes);
            this.grpOrder.Controls.Add(this.lblTotal);
            this.grpOrder.Controls.Add(this.txtSubtotal);
            this.grpOrder.Controls.Add(this.txtTotal);
            this.grpOrder.Controls.Add(this.lblEmployee);
            this.grpOrder.Controls.Add(this.lblCreationDate);
            this.grpOrder.Controls.Add(this.txtCreationDate);
            this.grpOrder.Location = new System.Drawing.Point(12, 213);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(789, 82);
            this.grpOrder.TabIndex = 13;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Purchase Order Information";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(655, 20);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(72, 20);
            this.txtStatus.TabIndex = 7;
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.Location = new System.Drawing.Point(61, 23);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(24, 13);
            this.lblPONumber.TabIndex = 0;
            this.lblPONumber.Text = "No:";
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(421, 20);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(147, 20);
            this.txtEmployee.TabIndex = 5;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(91, 20);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.ReadOnly = true;
            this.txtPONumber.Size = new System.Drawing.Size(72, 20);
            this.txtPONumber.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(580, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Order Status:";
            // 
            // txtTaxes
            // 
            this.txtTaxes.Location = new System.Drawing.Point(388, 52);
            this.txtTaxes.Name = "txtTaxes";
            this.txtTaxes.ReadOnly = true;
            this.txtTaxes.Size = new System.Drawing.Size(72, 20);
            this.txtTaxes.TabIndex = 11;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(203, 55);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 8;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblTaxes
            // 
            this.lblTaxes.AutoSize = true;
            this.lblTaxes.Location = new System.Drawing.Point(343, 55);
            this.lblTaxes.Name = "lblTaxes";
            this.lblTaxes.Size = new System.Drawing.Size(39, 13);
            this.lblTaxes.TabIndex = 10;
            this.lblTaxes.Text = "Taxes:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(473, 55);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(258, 52);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(72, 20);
            this.txtSubtotal.TabIndex = 9;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(513, 52);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(72, 20);
            this.txtTotal.TabIndex = 13;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(359, 23);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(56, 13);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "Employee:";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(175, 23);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(75, 13);
            this.lblCreationDate.TabIndex = 2;
            this.lblCreationDate.Text = "Creation Date:";
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Location = new System.Drawing.Point(256, 20);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(92, 20);
            this.txtCreationDate.TabIndex = 3;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(174, 315);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(465, 128);
            this.dgvItems.TabIndex = 5;
            // 
            // btnCancelItems
            // 
            this.btnCancelItems.Location = new System.Drawing.Point(655, 420);
            this.btnCancelItems.Name = "btnCancelItems";
            this.btnCancelItems.Size = new System.Drawing.Size(101, 23);
            this.btnCancelItems.TabIndex = 10;
            this.btnCancelItems.Text = "Ca&ncel";
            this.btnCancelItems.UseVisualStyleBackColor = true;
            this.btnCancelItems.Click += new System.EventHandler(this.btnCancelItems_Click);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(652, 314);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(109, 13);
            this.lblItems.TabIndex = 6;
            this.lblItems.Text = "Purchase Order Items";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(655, 333);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(101, 23);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "&Approve Item";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDeny
            // 
            this.btnDeny.Location = new System.Drawing.Point(655, 362);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(101, 23);
            this.btnDeny.TabIndex = 8;
            this.btnDeny.Text = "&Deny Item";
            this.btnDeny.UseVisualStyleBackColor = true;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // btnPending
            // 
            this.btnPending.Location = new System.Drawing.Point(655, 391);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(101, 23);
            this.btnPending.TabIndex = 9;
            this.btnPending.Text = "&Set to Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // txtDeny
            // 
            this.txtDeny.Location = new System.Drawing.Point(132, 14);
            this.txtDeny.MaxLength = 200;
            this.txtDeny.Name = "txtDeny";
            this.txtDeny.Size = new System.Drawing.Size(267, 20);
            this.txtDeny.TabIndex = 1;
            // 
            // lblDeny
            // 
            this.lblDeny.AutoSize = true;
            this.lblDeny.Location = new System.Drawing.Point(31, 17);
            this.lblDeny.Name = "lblDeny";
            this.lblDeny.Size = new System.Drawing.Size(98, 13);
            this.lblDeny.TabIndex = 0;
            this.lblDeny.Text = "Reason for Denial: ";
            // 
            // pnlDeny
            // 
            this.pnlDeny.Controls.Add(this.btnCancelDeny);
            this.pnlDeny.Controls.Add(this.btnDenyFinal);
            this.pnlDeny.Controls.Add(this.lblDeny);
            this.pnlDeny.Controls.Add(this.txtDeny);
            this.pnlDeny.Location = new System.Drawing.Point(87, 459);
            this.pnlDeny.Name = "pnlDeny";
            this.pnlDeny.Size = new System.Drawing.Size(639, 47);
            this.pnlDeny.TabIndex = 12;
            // 
            // btnCancelDeny
            // 
            this.btnCancelDeny.Location = new System.Drawing.Point(517, 12);
            this.btnCancelDeny.Name = "btnCancelDeny";
            this.btnCancelDeny.Size = new System.Drawing.Size(90, 23);
            this.btnCancelDeny.TabIndex = 3;
            this.btnCancelDeny.Text = "Ca&ncel";
            this.btnCancelDeny.UseVisualStyleBackColor = true;
            this.btnCancelDeny.Click += new System.EventHandler(this.btnCancelDeny_Click);
            // 
            // btnDenyFinal
            // 
            this.btnDenyFinal.Location = new System.Drawing.Point(417, 12);
            this.btnDenyFinal.Name = "btnDenyFinal";
            this.btnDenyFinal.Size = new System.Drawing.Size(90, 23);
            this.btnDenyFinal.TabIndex = 2;
            this.btnDenyFinal.Text = "&Deny Item";
            this.btnDenyFinal.UseVisualStyleBackColor = true;
            this.btnDenyFinal.Click += new System.EventHandler(this.btnDenyFinal_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(21, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Clos&e Purchase Order";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProcessPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlDeny);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnCancelItems);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.grpOrder);
            this.Controls.Add(this.lblPurchaseOrders);
            this.Controls.Add(this.btnCancelSearch);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.grpSearchOther);
            this.Name = "ProcessPurchaseOrder";
            this.Text = "Process Purchase Orders";
            this.Load += new System.EventHandler(this.ProcessPurchaseOrder_Load);
            this.grpSearchOther.ResumeLayout(false);
            this.grpSearchOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpOrder.ResumeLayout(false);
            this.grpOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlDeny.ResumeLayout(false);
            this.pnlDeny.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        internal System.Windows.Forms.GroupBox grpSearchOther;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoClosed;
        private System.Windows.Forms.RadioButton rdoPending;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnSearchDates;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblPurchaseOrders;
        internal System.Windows.Forms.Button btnCancelSearch;
        internal System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblPONumber;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtTaxes;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.DataGridView dgvItems;
        internal System.Windows.Forms.Button btnCancelItems;
        private System.Windows.Forms.Label lblItems;
        internal System.Windows.Forms.Button btnApprove;
        internal System.Windows.Forms.Button btnDeny;
        internal System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.TextBox txtDeny;
        private System.Windows.Forms.Label lblDeny;
        private System.Windows.Forms.Panel pnlDeny;
        internal System.Windows.Forms.Button btnDenyFinal;
        internal System.Windows.Forms.Button btnCancelDeny;
        internal System.Windows.Forms.Button btnClose;
    }
}