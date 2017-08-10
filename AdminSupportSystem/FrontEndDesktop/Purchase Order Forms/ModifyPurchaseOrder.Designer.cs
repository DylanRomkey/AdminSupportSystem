namespace FrontEndDesktop
{
    partial class ModifyPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyPurchaseOrder));
            this.grpSearchNumber = new System.Windows.Forms.GroupBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnSearchNumber = new System.Windows.Forms.Button();
            this.grpSearchOther = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoClosed = new System.Windows.Forms.RadioButton();
            this.rdoPending = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearchDates = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblPurchaseOrders = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.lblModReason = new System.Windows.Forms.Label();
            this.txtModReason = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblJustification = new System.Windows.Forms.Label();
            this.txtJustification = new System.Windows.Forms.TextBox();
            this.lblPurchaseLocation = new System.Windows.Forms.Label();
            this.txtPurchaseLocation = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTaxes = new System.Windows.Forms.Label();
            this.txtTaxes = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtSupervisor = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.btnCancelItems = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.grpSearchNumber.SuspendLayout();
            this.grpSearchOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlItem.SuspendLayout();
            this.grpOrder.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearchNumber
            // 
            this.grpSearchNumber.Controls.Add(this.txtNumber);
            this.grpSearchNumber.Controls.Add(this.btnSearchNumber);
            this.grpSearchNumber.Location = new System.Drawing.Point(38, 12);
            this.grpSearchNumber.Name = "grpSearchNumber";
            this.grpSearchNumber.Size = new System.Drawing.Size(198, 71);
            this.grpSearchNumber.TabIndex = 0;
            this.grpSearchNumber.TabStop = false;
            this.grpSearchNumber.Text = "Search by Order Number";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(11, 29);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(106, 20);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // btnSearchNumber
            // 
            this.btnSearchNumber.Location = new System.Drawing.Point(123, 27);
            this.btnSearchNumber.Name = "btnSearchNumber";
            this.btnSearchNumber.Size = new System.Drawing.Size(64, 23);
            this.btnSearchNumber.TabIndex = 1;
            this.btnSearchNumber.Text = "&Search";
            this.btnSearchNumber.UseVisualStyleBackColor = true;
            this.btnSearchNumber.Click += new System.EventHandler(this.btnSearchNumber_Click);
            // 
            // grpSearchOther
            // 
            this.grpSearchOther.Controls.Add(this.rdoAll);
            this.grpSearchOther.Controls.Add(this.rdoClosed);
            this.grpSearchOther.Controls.Add(this.rdoPending);
            this.grpSearchOther.Controls.Add(this.btnReset);
            this.grpSearchOther.Controls.Add(this.btnSearchDates);
            this.grpSearchOther.Controls.Add(this.lblEndDate);
            this.grpSearchOther.Controls.Add(this.lblStartDate);
            this.grpSearchOther.Controls.Add(this.dtpEndDate);
            this.grpSearchOther.Controls.Add(this.dtpStartDate);
            this.grpSearchOther.Location = new System.Drawing.Point(254, 12);
            this.grpSearchOther.Name = "grpSearchOther";
            this.grpSearchOther.Size = new System.Drawing.Size(519, 71);
            this.grpSearchOther.TabIndex = 1;
            this.grpSearchOther.TabStop = false;
            this.grpSearchOther.Text = "Search by Other";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(325, 13);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 2;
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
            this.rdoClosed.TabIndex = 4;
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
            this.rdoPending.TabIndex = 3;
            this.rdoPending.TabStop = true;
            this.rdoPending.Text = "Pending";
            this.rdoPending.UseVisualStyleBackColor = true;
            this.rdoPending.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(426, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(64, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Rese&t";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearchDates
            // 
            this.btnSearchDates.Location = new System.Drawing.Point(426, 13);
            this.btnSearchDates.Name = "btnSearchDates";
            this.btnSearchDates.Size = new System.Drawing.Size(64, 23);
            this.btnSearchDates.TabIndex = 5;
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
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "End Date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(63, 19);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 7;
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
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(169, 93);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(474, 101);
            this.dgvOrders.TabIndex = 3;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(655, 129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 23);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Select &Agreement";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Location = new System.Drawing.Point(655, 158);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(104, 23);
            this.btnCancelSearch.TabIndex = 6;
            this.btnCancelSearch.Text = "&Cancel Search";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(169, 297);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(474, 93);
            this.dgvItems.TabIndex = 7;
            // 
            // lblPurchaseOrders
            // 
            this.lblPurchaseOrders.AutoSize = true;
            this.lblPurchaseOrders.Location = new System.Drawing.Point(664, 104);
            this.lblPurchaseOrders.Name = "lblPurchaseOrders";
            this.lblPurchaseOrders.Size = new System.Drawing.Size(86, 13);
            this.lblPurchaseOrders.TabIndex = 4;
            this.lblPurchaseOrders.Text = "Purchase Orders";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(654, 297);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(109, 13);
            this.lblItems.TabIndex = 8;
            this.lblItems.Text = "Purchase Order Items";
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.Location = new System.Drawing.Point(657, 315);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(102, 23);
            this.btnSelectItem.TabIndex = 9;
            this.btnSelectItem.Text = "Select &Item";
            this.btnSelectItem.UseVisualStyleBackColor = true;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(87, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(139, 8);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(401, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(482, 8);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 20);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.lblModReason);
            this.pnlItem.Controls.Add(this.txtModReason);
            this.pnlItem.Controls.Add(this.btnRemove);
            this.pnlItem.Controls.Add(this.btnCancelEdit);
            this.pnlItem.Controls.Add(this.btnAddItem);
            this.pnlItem.Controls.Add(this.btnModify);
            this.pnlItem.Controls.Add(this.lblQuantity);
            this.pnlItem.Controls.Add(this.txtQuantity);
            this.pnlItem.Controls.Add(this.lblPrice);
            this.pnlItem.Controls.Add(this.txtPrice);
            this.pnlItem.Controls.Add(this.lblJustification);
            this.pnlItem.Controls.Add(this.txtJustification);
            this.pnlItem.Controls.Add(this.lblPurchaseLocation);
            this.pnlItem.Controls.Add(this.txtPurchaseLocation);
            this.pnlItem.Controls.Add(this.txtName);
            this.pnlItem.Controls.Add(this.lblDescription);
            this.pnlItem.Controls.Add(this.lblName);
            this.pnlItem.Controls.Add(this.txtDescription);
            this.pnlItem.Location = new System.Drawing.Point(48, 398);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(717, 128);
            this.pnlItem.TabIndex = 12;
            // 
            // lblModReason
            // 
            this.lblModReason.AutoSize = true;
            this.lblModReason.Location = new System.Drawing.Point(15, 89);
            this.lblModReason.Name = "lblModReason";
            this.lblModReason.Size = new System.Drawing.Size(110, 13);
            this.lblModReason.TabIndex = 14;
            this.lblModReason.Text = "Modification Reason: ";
            // 
            // txtModReason
            // 
            this.txtModReason.Location = new System.Drawing.Point(139, 86);
            this.txtModReason.MaxLength = 200;
            this.txtModReason.Name = "txtModReason";
            this.txtModReason.Size = new System.Drawing.Size(208, 20);
            this.txtModReason.TabIndex = 3;
            this.txtModReason.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(507, 96);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(86, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "&Remove Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(604, 96);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(86, 23);
            this.btnCancelEdit.TabIndex = 10;
            this.btnCancelEdit.Text = "Can&cel";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(605, 60);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(85, 23);
            this.btnAddItem.TabIndex = 9;
            this.btnAddItem.Text = "&Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(395, 96);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(102, 23);
            this.btnModify.TabIndex = 7;
            this.btnModify.Text = "&Modify Item";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(415, 63);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 17;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(482, 60);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(111, 20);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(430, 37);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 16;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(482, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(111, 20);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblJustification
            // 
            this.lblJustification.AutoSize = true;
            this.lblJustification.Location = new System.Drawing.Point(60, 63);
            this.lblJustification.Name = "lblJustification";
            this.lblJustification.Size = new System.Drawing.Size(65, 13);
            this.lblJustification.TabIndex = 13;
            this.lblJustification.Text = "Justification:";
            // 
            // txtJustification
            // 
            this.txtJustification.Location = new System.Drawing.Point(139, 60);
            this.txtJustification.MaxLength = 300;
            this.txtJustification.Name = "txtJustification";
            this.txtJustification.Size = new System.Drawing.Size(208, 20);
            this.txtJustification.TabIndex = 2;
            this.txtJustification.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblPurchaseLocation
            // 
            this.lblPurchaseLocation.AutoSize = true;
            this.lblPurchaseLocation.Location = new System.Drawing.Point(26, 37);
            this.lblPurchaseLocation.Name = "lblPurchaseLocation";
            this.lblPurchaseLocation.Size = new System.Drawing.Size(99, 13);
            this.lblPurchaseLocation.TabIndex = 12;
            this.lblPurchaseLocation.Text = "Purchase Location:";
            // 
            // txtPurchaseLocation
            // 
            this.txtPurchaseLocation.Location = new System.Drawing.Point(139, 34);
            this.txtPurchaseLocation.MaxLength = 100;
            this.txtPurchaseLocation.Name = "txtPurchaseLocation";
            this.txtPurchaseLocation.Size = new System.Drawing.Size(208, 20);
            this.txtPurchaseLocation.TabIndex = 1;
            this.txtPurchaseLocation.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(434, 52);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(72, 20);
            this.txtSubtotal.TabIndex = 13;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(379, 55);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 12;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblTaxes
            // 
            this.lblTaxes.AutoSize = true;
            this.lblTaxes.Location = new System.Drawing.Point(519, 55);
            this.lblTaxes.Name = "lblTaxes";
            this.lblTaxes.Size = new System.Drawing.Size(39, 13);
            this.lblTaxes.TabIndex = 14;
            this.lblTaxes.Text = "Taxes:";
            // 
            // txtTaxes
            // 
            this.txtTaxes.Location = new System.Drawing.Point(564, 52);
            this.txtTaxes.Name = "txtTaxes";
            this.txtTaxes.ReadOnly = true;
            this.txtTaxes.Size = new System.Drawing.Size(72, 20);
            this.txtTaxes.TabIndex = 15;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(689, 52);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(72, 20);
            this.txtTotal.TabIndex = 17;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(649, 55);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total:";
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(63, 20);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.ReadOnly = true;
            this.txtPONumber.Size = new System.Drawing.Size(72, 20);
            this.txtPONumber.TabIndex = 1;
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.Location = new System.Drawing.Point(33, 23);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(24, 13);
            this.lblPONumber.TabIndex = 0;
            this.lblPONumber.Text = "No:";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(147, 23);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(75, 13);
            this.lblCreationDate.TabIndex = 2;
            this.lblCreationDate.Text = "Creation Date:";
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Location = new System.Drawing.Point(228, 20);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(92, 20);
            this.txtCreationDate.TabIndex = 3;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(390, 20);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(147, 20);
            this.txtEmployee.TabIndex = 5;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(328, 23);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(56, 13);
            this.lblEmployee.TabIndex = 4;
            this.lblEmployee.Text = "Employee:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(614, 20);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(147, 20);
            this.txtDepartment.TabIndex = 7;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(543, 23);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "Department:";
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.Location = new System.Drawing.Point(93, 52);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.ReadOnly = true;
            this.txtSupervisor.Size = new System.Drawing.Size(107, 20);
            this.txtSupervisor.TabIndex = 9;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(27, 55);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(60, 13);
            this.lblSupervisor.TabIndex = 8;
            this.lblSupervisor.Text = "Supervisor:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(288, 52);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(72, 20);
            this.txtStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(213, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Order Status:";
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.txtStatus);
            this.grpOrder.Controls.Add(this.lblPONumber);
            this.grpOrder.Controls.Add(this.txtEmployee);
            this.grpOrder.Controls.Add(this.txtPONumber);
            this.grpOrder.Controls.Add(this.lblStatus);
            this.grpOrder.Controls.Add(this.txtTaxes);
            this.grpOrder.Controls.Add(this.txtSupervisor);
            this.grpOrder.Controls.Add(this.lblSubtotal);
            this.grpOrder.Controls.Add(this.lblSupervisor);
            this.grpOrder.Controls.Add(this.lblTaxes);
            this.grpOrder.Controls.Add(this.txtDepartment);
            this.grpOrder.Controls.Add(this.lblTotal);
            this.grpOrder.Controls.Add(this.lblDepartment);
            this.grpOrder.Controls.Add(this.txtSubtotal);
            this.grpOrder.Controls.Add(this.txtTotal);
            this.grpOrder.Controls.Add(this.lblEmployee);
            this.grpOrder.Controls.Add(this.lblCreationDate);
            this.grpOrder.Controls.Add(this.txtCreationDate);
            this.grpOrder.Location = new System.Drawing.Point(12, 205);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(789, 82);
            this.grpOrder.TabIndex = 13;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Purchase Order Information";
            // 
            // btnCancelItems
            // 
            this.btnCancelItems.Location = new System.Drawing.Point(657, 367);
            this.btnCancelItems.Name = "btnCancelItems";
            this.btnCancelItems.Size = new System.Drawing.Size(101, 23);
            this.btnCancelItems.TabIndex = 11;
            this.btnCancelItems.Text = "Ca&ncel";
            this.btnCancelItems.UseVisualStyleBackColor = true;
            this.btnCancelItems.Click += new System.EventHandler(this.btnCancelItems_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(657, 341);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add &New Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblEmployeeName);
            this.grpFilter.Controls.Add(this.txtEmployeeName);
            this.grpFilter.Location = new System.Drawing.Point(38, 89);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(117, 105);
            this.grpFilter.TabIndex = 2;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter by Employee";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(16, 34);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 1;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(8, 58);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(101, 20);
            this.txtEmployeeName.TabIndex = 0;
            this.txtEmployeeName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(779, 39);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(21, 20);
            this.txtFilter.TabIndex = 14;
            // 
            // ModifyPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancelItems);
            this.Controls.Add(this.grpOrder);
            this.Controls.Add(this.pnlItem);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblPurchaseOrders);
            this.Controls.Add(this.btnSelectItem);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.btnCancelSearch);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grpSearchOther);
            this.Controls.Add(this.grpSearchNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyPurchaseOrder";
            this.Text = "Modify Purchase Orders";
            this.Load += new System.EventHandler(this.ModifyPurchaseOrder_Load);
            this.grpSearchNumber.ResumeLayout(false);
            this.grpSearchNumber.PerformLayout();
            this.grpSearchOther.ResumeLayout(false);
            this.grpSearchOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            this.grpOrder.ResumeLayout(false);
            this.grpOrder.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpSearchNumber;
        internal System.Windows.Forms.TextBox txtNumber;
        internal System.Windows.Forms.Button btnSearchNumber;
        internal System.Windows.Forms.GroupBox grpSearchOther;
        internal System.Windows.Forms.Button btnSearchDates;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridView dgvOrders;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.Button btnCancelSearch;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblPurchaseOrders;
        private System.Windows.Forms.Label lblItems;
        internal System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Label lblPurchaseLocation;
        private System.Windows.Forms.TextBox txtPurchaseLocation;
        private System.Windows.Forms.Label lblJustification;
        private System.Windows.Forms.TextBox txtJustification;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.TextBox txtTaxes;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Button btnAddItem;
        internal System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtSupervisor;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Label lblPONumber;
        private System.Windows.Forms.GroupBox grpOrder;
        internal System.Windows.Forms.Button btnCancelItems;
        internal System.Windows.Forms.Button btnCancelEdit;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblModReason;
        private System.Windows.Forms.TextBox txtModReason;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeName;
        internal System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoClosed;
        private System.Windows.Forms.RadioButton rdoPending;
        private System.Windows.Forms.TextBox txtFilter;
    }
}