namespace FrontEndDesktop
{
    partial class CreatePurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePurchaseOrder));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPurchaseLocation = new System.Windows.Forms.Label();
            this.txtPurchaseLocation = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lblJustification = new System.Windows.Forms.Label();
            this.txtJustification = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.lblPurchaseOrder = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.txtSupervisor = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtTaxes = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTaxes = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlTotals = new System.Windows.Forms.Panel();
            this.btnClearItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlTotals.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(325, 130);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(325, 160);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(269, 133);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(244, 163);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(273, 292);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(325, 289);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(111, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblPurchaseLocation
            // 
            this.lblPurchaseLocation.AutoSize = true;
            this.lblPurchaseLocation.Location = new System.Drawing.Point(208, 193);
            this.lblPurchaseLocation.Name = "lblPurchaseLocation";
            this.lblPurchaseLocation.Size = new System.Drawing.Size(99, 13);
            this.lblPurchaseLocation.TabIndex = 15;
            this.lblPurchaseLocation.Text = "Purchase Location:";
            // 
            // txtPurchaseLocation
            // 
            this.txtPurchaseLocation.Location = new System.Drawing.Point(325, 190);
            this.txtPurchaseLocation.MaxLength = 100;
            this.txtPurchaseLocation.Name = "txtPurchaseLocation";
            this.txtPurchaseLocation.Size = new System.Drawing.Size(280, 20);
            this.txtPurchaseLocation.TabIndex = 2;
            this.txtPurchaseLocation.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(258, 322);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(325, 319);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(111, 20);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(159, 352);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(552, 352);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear &Item List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(242, 352);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(92, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "&Remove Item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(342, 352);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(92, 23);
            this.btnComplete.TabIndex = 8;
            this.btnComplete.Text = "&Complete Order";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lblJustification
            // 
            this.lblJustification.AutoSize = true;
            this.lblJustification.Location = new System.Drawing.Point(242, 223);
            this.lblJustification.Name = "lblJustification";
            this.lblJustification.Size = new System.Drawing.Size(65, 13);
            this.lblJustification.TabIndex = 16;
            this.lblJustification.Text = "Justification:";
            // 
            // txtJustification
            // 
            this.txtJustification.Location = new System.Drawing.Point(325, 220);
            this.txtJustification.MaxLength = 300;
            this.txtJustification.Multiline = true;
            this.txtJustification.Name = "txtJustification";
            this.txtJustification.Size = new System.Drawing.Size(280, 59);
            this.txtJustification.TabIndex = 3;
            this.txtJustification.Enter += new System.EventHandler(this.txtName_Enter);
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(165, 389);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(305, 121);
            this.dgvItems.TabIndex = 10;
            // 
            // lblPurchaseOrder
            // 
            this.lblPurchaseOrder.AutoSize = true;
            this.lblPurchaseOrder.Location = new System.Drawing.Point(240, 94);
            this.lblPurchaseOrder.Name = "lblPurchaseOrder";
            this.lblPurchaseOrder.Size = new System.Drawing.Size(328, 13);
            this.lblPurchaseOrder.TabIndex = 12;
            this.lblPurchaseOrder.Text = "Please enter in all item information to add it to a new Purchase Order";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(221, 16);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(179, 20);
            this.txtEmployeeName.TabIndex = 21;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(124, 19);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(87, 13);
            this.lblEmployeeName.TabIndex = 19;
            this.lblEmployeeName.Text = "Employee Name:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(433, 19);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 23;
            this.lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(509, 16);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(179, 20);
            this.txtDepartment.TabIndex = 25;
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(151, 54);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(60, 13);
            this.lblSupervisor.TabIndex = 20;
            this.lblSupervisor.Text = "Supervisor:";
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.Location = new System.Drawing.Point(221, 51);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.ReadOnly = true;
            this.txtSupervisor.Size = new System.Drawing.Size(179, 20);
            this.txtSupervisor.TabIndex = 22;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(465, 54);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(509, 51);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(179, 20);
            this.txtDate.TabIndex = 26;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(60, 4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtSubtotal.TabIndex = 3;
            // 
            // txtTaxes
            // 
            this.txtTaxes.Location = new System.Drawing.Point(60, 30);
            this.txtTaxes.Name = "txtTaxes";
            this.txtTaxes.ReadOnly = true;
            this.txtTaxes.Size = new System.Drawing.Size(100, 20);
            this.txtTaxes.TabIndex = 4;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(60, 56);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 5;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(5, 7);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(49, 13);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblTaxes
            // 
            this.lblTaxes.AutoSize = true;
            this.lblTaxes.Location = new System.Drawing.Point(15, 33);
            this.lblTaxes.Name = "lblTaxes";
            this.lblTaxes.Size = new System.Drawing.Size(39, 13);
            this.lblTaxes.TabIndex = 1;
            this.lblTaxes.Text = "Taxes:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(15, 59);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total:";
            // 
            // pnlTotals
            // 
            this.pnlTotals.Controls.Add(this.txtTotal);
            this.pnlTotals.Controls.Add(this.lblTotal);
            this.pnlTotals.Controls.Add(this.txtSubtotal);
            this.pnlTotals.Controls.Add(this.lblTaxes);
            this.pnlTotals.Controls.Add(this.txtTaxes);
            this.pnlTotals.Controls.Add(this.lblSubtotal);
            this.pnlTotals.Location = new System.Drawing.Point(476, 410);
            this.pnlTotals.Name = "pnlTotals";
            this.pnlTotals.Size = new System.Drawing.Size(171, 79);
            this.pnlTotals.TabIndex = 11;
            // 
            // btnClearItem
            // 
            this.btnClearItem.Location = new System.Drawing.Point(442, 352);
            this.btnClearItem.Name = "btnClearItem";
            this.btnClearItem.Size = new System.Drawing.Size(102, 23);
            this.btnClearItem.TabIndex = 27;
            this.btnClearItem.Text = "C&lear";
            this.btnClearItem.UseVisualStyleBackColor = true;
            this.btnClearItem.Click += new System.EventHandler(this.btnClearItem_Click);
            // 
            // CreatePurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 538);
            this.Controls.Add(this.btnClearItem);
            this.Controls.Add(this.pnlTotals);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblSupervisor);
            this.Controls.Add(this.txtSupervisor);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.lblPurchaseOrder);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.lblJustification);
            this.Controls.Add(this.txtJustification);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblPurchaseLocation);
            this.Controls.Add(this.txtPurchaseLocation);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePurchaseOrder";
            this.Text = "Create Purchase Order";
            this.Load += new System.EventHandler(this.CreatePurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlTotals.ResumeLayout(false);
            this.pnlTotals.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPurchaseLocation;
        private System.Windows.Forms.TextBox txtPurchaseLocation;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblJustification;
        private System.Windows.Forms.TextBox txtJustification;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblPurchaseOrder;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.TextBox txtSupervisor;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtTaxes;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Button btnClearItem;
    }
}

