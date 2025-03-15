namespace BookHaven.Forms
{
    partial class OrderManagementForm
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
            lblTitle = new Label();
            btnExit = new Button();
            label1 = new Label();
            cmbCustomers = new ComboBox();
            label2 = new Label();
            cmbBooks = new ComboBox();
            label3 = new Label();
            txtQuantity = new TextBox();
            btnAddToOrder = new Button();
            dgvOrderDetails = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            lblTotalAmount = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cmbOrderStatus = new ComboBox();
            cmbPaymentStatus = new ComboBox();
            cmbDeliveryType = new ComboBox();
            dtpExpectedDeliveryDate = new DateTimePicker();
            btnCreateOrder = new Button();
            btnUpdateOrder = new Button();
            btnDeleteOrder = new Button();
            btnClearForm = new Button();
            label11 = new Label();
            dgvOrders = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("SF Pro Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ControlText;
            lblTitle.Location = new Point(440, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(254, 32);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Order Management";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(27, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 37);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 157);
            label1.Name = "label1";
            label1.Size = new Size(131, 19);
            label1.TabIndex = 4;
            label1.Text = "Select Customer";
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(264, 157);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(149, 23);
            cmbCustomers.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(59, 209);
            label2.Name = "label2";
            label2.Size = new Size(96, 19);
            label2.TabIndex = 6;
            label2.Text = "Select Book";
            // 
            // cmbBooks
            // 
            cmbBooks.FormattingEnabled = true;
            cmbBooks.Location = new Point(264, 209);
            cmbBooks.Name = "cmbBooks";
            cmbBooks.Size = new Size(149, 23);
            cmbBooks.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(59, 239);
            label3.Name = "label3";
            label3.Size = new Size(73, 19);
            label3.TabIndex = 8;
            label3.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(264, 239);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(68, 23);
            txtQuantity.TabIndex = 9;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToOrder.Location = new Point(328, 321);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(85, 45);
            btnAddToOrder.TabIndex = 10;
            btnAddToOrder.Text = "ADD TO ORDER";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Location = new Point(527, 179);
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.Size = new Size(491, 187);
            dgvOrderDetails.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(525, 157);
            label4.Name = "label4";
            label4.Size = new Size(113, 19);
            label4.TabIndex = 12;
            label4.Text = "Order Details :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 333);
            label5.Name = "label5";
            label5.Size = new Size(139, 19);
            label5.TabIndex = 13;
            label5.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.DarkRed;
            lblTotalAmount.Location = new Point(209, 333);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(0, 19);
            lblTotalAmount.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            label6.Location = new Point(59, 492);
            label6.Name = "label6";
            label6.Size = new Size(88, 16);
            label6.TabIndex = 15;
            label6.Text = "Order Status:";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            label7.Location = new Point(59, 528);
            label7.Name = "label7";
            label7.Size = new Size(105, 16);
            label7.TabIndex = 16;
            label7.Text = "Payment Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(59, 438);
            label8.Name = "label8";
            label8.Size = new Size(155, 19);
            label8.TabIndex = 17;
            label8.Text = "Order Configuration";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            label9.Location = new Point(59, 565);
            label9.Name = "label9";
            label9.Size = new Size(91, 16);
            label9.TabIndex = 18;
            label9.Text = "Delivery Type:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            label10.Location = new Point(59, 603);
            label10.Name = "label10";
            label10.Size = new Size(149, 16);
            label10.TabIndex = 19;
            label10.Text = "Expected Delivery Date:";
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Items.AddRange(new object[] { "Pending", "Completed", "Cancelled" });
            cmbOrderStatus.Location = new Point(264, 490);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(149, 23);
            cmbOrderStatus.TabIndex = 20;
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Items.AddRange(new object[] { "Pending", "Completed" });
            cmbPaymentStatus.Location = new Point(264, 526);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(149, 23);
            cmbPaymentStatus.TabIndex = 21;
            // 
            // cmbDeliveryType
            // 
            cmbDeliveryType.FormattingEnabled = true;
            cmbDeliveryType.Items.AddRange(new object[] { "Pickup", "Delivery" });
            cmbDeliveryType.Location = new Point(264, 563);
            cmbDeliveryType.Name = "cmbDeliveryType";
            cmbDeliveryType.Size = new Size(149, 23);
            cmbDeliveryType.TabIndex = 22;
            // 
            // dtpExpectedDeliveryDate
            // 
            dtpExpectedDeliveryDate.Location = new Point(264, 598);
            dtpExpectedDeliveryDate.Name = "dtpExpectedDeliveryDate";
            dtpExpectedDeliveryDate.Size = new Size(189, 23);
            dtpExpectedDeliveryDate.TabIndex = 23;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnCreateOrder.Location = new Point(59, 680);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(91, 48);
            btnCreateOrder.TabIndex = 24;
            btnCreateOrder.Text = "Create\r\nOrder";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // btnUpdateOrder
            // 
            btnUpdateOrder.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnUpdateOrder.Location = new Point(163, 680);
            btnUpdateOrder.Name = "btnUpdateOrder";
            btnUpdateOrder.Size = new Size(91, 48);
            btnUpdateOrder.TabIndex = 25;
            btnUpdateOrder.Text = "Update\r\nOrder";
            btnUpdateOrder.UseVisualStyleBackColor = true;
            btnUpdateOrder.Click += btnUpdateOrder_Click;
            // 
            // btnDeleteOrder
            // 
            btnDeleteOrder.BackColor = Color.DarkRed;
            btnDeleteOrder.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnDeleteOrder.ForeColor = Color.White;
            btnDeleteOrder.Location = new Point(264, 680);
            btnDeleteOrder.Name = "btnDeleteOrder";
            btnDeleteOrder.Size = new Size(91, 48);
            btnDeleteOrder.TabIndex = 26;
            btnDeleteOrder.Text = "Delete\r\nOrder";
            btnDeleteOrder.UseVisualStyleBackColor = false;
            btnDeleteOrder.Click += btnDeleteOrder_Click;
            // 
            // btnClearForm
            // 
            btnClearForm.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnClearForm.Location = new Point(365, 680);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(91, 48);
            btnClearForm.TabIndex = 27;
            btnClearForm.Text = "Clear";
            btnClearForm.UseVisualStyleBackColor = true;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(525, 438);
            label11.Name = "label11";
            label11.Size = new Size(86, 19);
            label11.TabIndex = 28;
            label11.Text = "Order List:";
            // 
            // dgvOrders
            // 
            dgvOrders.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(527, 460);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(491, 268);
            dgvOrders.TabIndex = 29;
            dgvOrders.CellContentClick += dgvOrders_CellContentClick;
            // 
            // OrderManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1094, 780);
            Controls.Add(dgvOrders);
            Controls.Add(label11);
            Controls.Add(btnClearForm);
            Controls.Add(btnDeleteOrder);
            Controls.Add(btnUpdateOrder);
            Controls.Add(btnCreateOrder);
            Controls.Add(dtpExpectedDeliveryDate);
            Controls.Add(cmbDeliveryType);
            Controls.Add(cmbPaymentStatus);
            Controls.Add(cmbOrderStatus);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lblTotalAmount);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvOrderDetails);
            Controls.Add(btnAddToOrder);
            Controls.Add(txtQuantity);
            Controls.Add(label3);
            Controls.Add(cmbBooks);
            Controls.Add(label2);
            Controls.Add(cmbCustomers);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrderManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OrderManagementForm";
            Load += OrderManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnExit;
        private Label label1;
        private ComboBox cmbCustomers;
        private Label label2;
        private ComboBox cmbBooks;
        private Label label3;
        private TextBox txtQuantity;
        private Button btnAddToOrder;
        private DataGridView dgvOrderDetails;
        private Label label4;
        private Label label5;
        private Label lblTotalAmount;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cmbOrderStatus;
        private ComboBox cmbPaymentStatus;
        private ComboBox cmbDeliveryType;
        private DateTimePicker dtpExpectedDeliveryDate;
        private Button btnCreateOrder;
        private Button btnUpdateOrder;
        private Button btnDeleteOrder;
        private Button btnClearForm;
        private Label label11;
        private DataGridView dgvOrders;
    }
}