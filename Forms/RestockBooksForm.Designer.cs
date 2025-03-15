namespace BookHaven.Forms
{
    partial class RestockBooksForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblBookTitle = new Label();
            lblCurrentStock = new Label();
            lblSupplierName = new Label();
            btnClose = new Button();
            label5 = new Label();
            txtRestockQuantity = new TextBox();
            btnPlaceOrder = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(144, 34);
            label1.Name = "label1";
            label1.Size = new Size(152, 25);
            label1.TabIndex = 0;
            label1.Text = "Restock Books";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 105);
            label2.Name = "label2";
            label2.Size = new Size(77, 18);
            label2.TabIndex = 1;
            label2.Text = "Book Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 145);
            label3.Name = "label3";
            label3.Size = new Size(102, 18);
            label3.TabIndex = 2;
            label3.Text = "Current Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 184);
            label4.Name = "label4";
            label4.Size = new Size(108, 18);
            label4.TabIndex = 3;
            label4.Text = "Supplier Name";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.ForeColor = Color.DarkRed;
            lblBookTitle.Location = new Point(190, 105);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(0, 18);
            lblBookTitle.TabIndex = 4;
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.ForeColor = Color.DarkRed;
            lblCurrentStock.Location = new Point(190, 145);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(0, 18);
            lblCurrentStock.TabIndex = 5;
            // 
            // lblSupplierName
            // 
            lblSupplierName.AutoSize = true;
            lblSupplierName.ForeColor = Color.DarkRed;
            lblSupplierName.Location = new Point(190, 184);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(0, 18);
            lblSupplierName.TabIndex = 6;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("SF Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.DarkRed;
            btnClose.Location = new Point(383, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(64, 37);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 249);
            label5.Name = "label5";
            label5.Size = new Size(126, 18);
            label5.TabIndex = 8;
            label5.Text = "Restock Quantity";
            // 
            // txtRestockQuantity
            // 
            txtRestockQuantity.Location = new Point(190, 246);
            txtRestockQuantity.Name = "txtRestockQuantity";
            txtRestockQuantity.Size = new Size(90, 25);
            txtRestockQuantity.TabIndex = 9;
            // 
            // btnPlaceOrder
            // 
            btnPlaceOrder.BackColor = SystemColors.ActiveCaption;
            btnPlaceOrder.Font = new Font("SF Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlaceOrder.Location = new Point(29, 307);
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new Size(77, 52);
            btnPlaceOrder.TabIndex = 10;
            btnPlaceOrder.Text = "Place Order";
            btnPlaceOrder.UseVisualStyleBackColor = false;
            btnPlaceOrder.Click += btnPlaceOrder_Click;
            // 
            // RestockBooksForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(459, 390);
            Controls.Add(btnPlaceOrder);
            Controls.Add(txtRestockQuantity);
            Controls.Add(label5);
            Controls.Add(btnClose);
            Controls.Add(lblSupplierName);
            Controls.Add(lblCurrentStock);
            Controls.Add(lblBookTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("SF Pro Display", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "RestockBooksForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restock Books";
            Load += RestockBooksForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblBookTitle;
        private Label lblCurrentStock;
        private Label lblSupplierName;
        private Button btnClose;
        private Label label5;
        private TextBox txtRestockQuantity;
        private Button btnPlaceOrder;
    }
}