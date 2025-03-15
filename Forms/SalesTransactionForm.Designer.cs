namespace BookHaven.Forms
{
    partial class SalesTransactionForm
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
            label1 = new Label();
            btnExit = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbCustomers = new ComboBox();
            cmbBooks = new ComboBox();
            txtQuantity = new TextBox();
            btnAddToCart = new Button();
            dgvCart = new DataGridView();
            btnRemoveItem = new Button();
            label6 = new Label();
            lblTotalAmount = new Label();
            label7 = new Label();
            txtDiscount = new TextBox();
            label8 = new Label();
            lblFinalAmount = new Label();
            label9 = new Label();
            cmbPaymentMethod = new ComboBox();
            btnProcessPayment = new Button();
            btnGenerateInvoice = new Button();
            btnCancelTransaction = new Button();
            btnClearForm = new Button();
            label10 = new Label();
            dgvSalesHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalesHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(440, 40);
            label1.Name = "label1";
            label1.Size = new Size(233, 32);
            label1.TabIndex = 0;
            label1.Text = "Sales Transaction";
            // 
            // btnExit
            // 
            btnExit.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(27, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 37);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(59, 121);
            label2.Name = "label2";
            label2.Size = new Size(131, 19);
            label2.TabIndex = 5;
            label2.Text = "Select Customer";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(59, 169);
            label3.Name = "label3";
            label3.Size = new Size(96, 19);
            label3.TabIndex = 6;
            label3.Text = "Select Book";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 216);
            label4.Name = "label4";
            label4.Size = new Size(73, 19);
            label4.TabIndex = 7;
            label4.Text = "Quantity";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(520, 119);
            label5.Name = "label5";
            label5.Size = new Size(41, 19);
            label5.TabIndex = 8;
            label5.Text = "Cart";
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(240, 121);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(139, 23);
            cmbCustomers.TabIndex = 9;
            // 
            // cmbBooks
            // 
            cmbBooks.FormattingEnabled = true;
            cmbBooks.Location = new Point(240, 169);
            cmbBooks.Name = "cmbBooks";
            cmbBooks.Size = new Size(139, 23);
            cmbBooks.TabIndex = 10;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(240, 216);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(84, 23);
            txtQuantity.TabIndex = 11;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToCart.Location = new Point(240, 272);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(87, 47);
            btnAddToCart.TabIndex = 12;
            btnAddToCart.Text = "ADD TO CART";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(523, 141);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(467, 178);
            dgvCart.TabIndex = 13;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnRemoveItem.Location = new Point(903, 325);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(87, 47);
            btnRemoveItem.TabIndex = 14;
            btnRemoveItem.Text = "Remove Item";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(59, 395);
            label6.Name = "label6";
            label6.Size = new Size(110, 19);
            label6.TabIndex = 15;
            label6.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.DarkRed;
            lblTotalAmount.Location = new Point(240, 395);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(0, 19);
            lblTotalAmount.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(59, 441);
            label7.Name = "label7";
            label7.Size = new Size(78, 19);
            label7.TabIndex = 17;
            label7.Text = "Discount:";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(240, 441);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(100, 23);
            txtDiscount.TabIndex = 18;
            txtDiscount.KeyPress += txtDiscount_KeyPress;
            txtDiscount.Leave += txtDiscount_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(59, 487);
            label8.Name = "label8";
            label8.Size = new Size(109, 19);
            label8.TabIndex = 19;
            label8.Text = "Final Amount:";
            // 
            // lblFinalAmount
            // 
            lblFinalAmount.AutoSize = true;
            lblFinalAmount.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinalAmount.ForeColor = Color.DarkRed;
            lblFinalAmount.Location = new Point(240, 487);
            lblFinalAmount.Name = "lblFinalAmount";
            lblFinalAmount.Size = new Size(0, 19);
            lblFinalAmount.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(59, 532);
            label9.Name = "label9";
            label9.Size = new Size(134, 19);
            label9.TabIndex = 21;
            label9.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Card", "Online" });
            cmbPaymentMethod.Location = new Point(240, 532);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(139, 23);
            cmbPaymentMethod.TabIndex = 22;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnProcessPayment.Location = new Point(59, 584);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(87, 47);
            btnProcessPayment.TabIndex = 23;
            btnProcessPayment.Text = "Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = true;
            btnProcessPayment.Click += btnProcessPayment_Click;
            // 
            // btnGenerateInvoice
            // 
            btnGenerateInvoice.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnGenerateInvoice.Location = new Point(523, 395);
            btnGenerateInvoice.Name = "btnGenerateInvoice";
            btnGenerateInvoice.Size = new Size(87, 47);
            btnGenerateInvoice.TabIndex = 24;
            btnGenerateInvoice.Text = "Generate Invoice";
            btnGenerateInvoice.UseVisualStyleBackColor = true;
            btnGenerateInvoice.Click += btnGenerateInvoice_Click;
            // 
            // btnCancelTransaction
            // 
            btnCancelTransaction.BackColor = Color.DarkRed;
            btnCancelTransaction.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnCancelTransaction.ForeColor = Color.White;
            btnCancelTransaction.Location = new Point(523, 459);
            btnCancelTransaction.Name = "btnCancelTransaction";
            btnCancelTransaction.Size = new Size(108, 60);
            btnCancelTransaction.TabIndex = 25;
            btnCancelTransaction.Text = "Cancel Transaction";
            btnCancelTransaction.UseVisualStyleBackColor = false;
            btnCancelTransaction.Click += btnCancelTransaction_Click;
            // 
            // btnClearForm
            // 
            btnClearForm.BackColor = Color.White;
            btnClearForm.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnClearForm.ForeColor = Color.Black;
            btnClearForm.Location = new Point(523, 536);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(82, 47);
            btnClearForm.TabIndex = 26;
            btnClearForm.Text = "Clear \r\nForm";
            btnClearForm.UseVisualStyleBackColor = false;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("SF Pro Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(59, 679);
            label10.Name = "label10";
            label10.Size = new Size(188, 23);
            label10.TabIndex = 27;
            label10.Text = "Recent Transactions";
            // 
            // dgvSalesHistory
            // 
            dgvSalesHistory.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvSalesHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesHistory.Location = new Point(59, 721);
            dgvSalesHistory.Name = "dgvSalesHistory";
            dgvSalesHistory.Size = new Size(882, 332);
            dgvSalesHistory.TabIndex = 28;
            // 
            // SalesTransactionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1094, 1110);
            Controls.Add(dgvSalesHistory);
            Controls.Add(label10);
            Controls.Add(btnClearForm);
            Controls.Add(btnCancelTransaction);
            Controls.Add(btnGenerateInvoice);
            Controls.Add(btnProcessPayment);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label9);
            Controls.Add(lblFinalAmount);
            Controls.Add(label8);
            Controls.Add(txtDiscount);
            Controls.Add(label7);
            Controls.Add(lblTotalAmount);
            Controls.Add(label6);
            Controls.Add(btnRemoveItem);
            Controls.Add(dgvCart);
            Controls.Add(btnAddToCart);
            Controls.Add(txtQuantity);
            Controls.Add(cmbBooks);
            Controls.Add(cmbCustomers);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnExit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesTransactionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SalesTransactionForm";
            Load += SalesTransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSalesHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnExit;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbCustomers;
        private ComboBox cmbBooks;
        private TextBox txtQuantity;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Button btnRemoveItem;
        private Label label6;
        private Label lblTotalAmount;
        private Label label7;
        private TextBox txtDiscount;
        private Label label8;
        private Label lblFinalAmount;
        private Label label9;
        private ComboBox cmbPaymentMethod;
        private Button btnProcessPayment;
        private Button btnGenerateInvoice;
        private Button btnCancelTransaction;
        private Button btnClearForm;
        private Label label10;
        private DataGridView dgvSalesHistory;
    }
}