namespace BookHaven.Forms
{
    partial class SupplierManagementForm
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
            label6 = new Label();
            txtSupplierName = new TextBox();
            txtContactPerson = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnAddSupplier = new Button();
            btnUpdateSupplier = new Button();
            btnDeleteSupplier = new Button();
            btnClear = new Button();
            dgvLowStockBooks = new DataGridView();
            btnRestock = new Button();
            label7 = new Label();
            dgvSuppliers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLowStockBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(438, 37);
            label1.Name = "label1";
            label1.Size = new Size(286, 32);
            label1.TabIndex = 0;
            label1.Text = "Supplier Management";
            label1.Click += label1_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(27, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 37);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(57, 136);
            label2.Name = "label2";
            label2.Size = new Size(115, 19);
            label2.TabIndex = 6;
            label2.Text = "Supplier Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(57, 181);
            label3.Name = "label3";
            label3.Size = new Size(122, 19);
            label3.TabIndex = 7;
            label3.Text = "Contact Person";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(57, 227);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(57, 274);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 9;
            label5.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(57, 321);
            label6.Name = "label6";
            label6.Size = new Size(71, 19);
            label6.TabIndex = 10;
            label6.Text = "Address";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(227, 136);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(146, 23);
            txtSupplierName.TabIndex = 11;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(227, 181);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(146, 23);
            txtContactPerson.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(227, 227);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(146, 23);
            txtEmail.TabIndex = 13;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(227, 274);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(146, 23);
            txtPhone.TabIndex = 14;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(227, 321);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(146, 23);
            txtAddress.TabIndex = 15;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnAddSupplier.Location = new Point(435, 136);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(89, 54);
            btnAddSupplier.TabIndex = 16;
            btnAddSupplier.Text = "ADD SUPPLIER";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // btnUpdateSupplier
            // 
            btnUpdateSupplier.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnUpdateSupplier.Location = new Point(435, 199);
            btnUpdateSupplier.Name = "btnUpdateSupplier";
            btnUpdateSupplier.Size = new Size(89, 54);
            btnUpdateSupplier.TabIndex = 17;
            btnUpdateSupplier.Text = "Update Supplier";
            btnUpdateSupplier.UseVisualStyleBackColor = true;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            // 
            // btnDeleteSupplier
            // 
            btnDeleteSupplier.BackColor = Color.DarkRed;
            btnDeleteSupplier.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnDeleteSupplier.ForeColor = Color.White;
            btnDeleteSupplier.Location = new Point(435, 262);
            btnDeleteSupplier.Name = "btnDeleteSupplier";
            btnDeleteSupplier.Size = new Size(89, 54);
            btnDeleteSupplier.TabIndex = 18;
            btnDeleteSupplier.Text = "Delete Supplier";
            btnDeleteSupplier.UseVisualStyleBackColor = false;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnClear.Location = new Point(534, 136);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 54);
            btnClear.TabIndex = 19;
            btnClear.Text = "Clear\r\nForm";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvLowStockBooks
            // 
            dgvLowStockBooks.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvLowStockBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLowStockBooks.Location = new Point(57, 427);
            dgvLowStockBooks.Name = "dgvLowStockBooks";
            dgvLowStockBooks.Size = new Size(771, 271);
            dgvLowStockBooks.TabIndex = 20;
            dgvLowStockBooks.CellContentClick += dgvLowStockBooks_CellContentClick;
            // 
            // btnRestock
            // 
            btnRestock.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestock.Location = new Point(834, 644);
            btnRestock.Name = "btnRestock";
            btnRestock.Size = new Size(82, 54);
            btnRestock.TabIndex = 21;
            btnRestock.Text = "Restock Books";
            btnRestock.UseVisualStyleBackColor = true;
            btnRestock.Click += btnRestock_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Pro Display", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(54, 399);
            label7.Name = "label7";
            label7.Size = new Size(126, 18);
            label7.TabIndex = 22;
            label7.Text = "Low Stock Books";
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(641, 136);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(482, 265);
            dgvSuppliers.TabIndex = 23;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // SupplierManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1175, 750);
            Controls.Add(dgvSuppliers);
            Controls.Add(label7);
            Controls.Add(btnRestock);
            Controls.Add(dgvLowStockBooks);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteSupplier);
            Controls.Add(btnUpdateSupplier);
            Controls.Add(btnAddSupplier);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtContactPerson);
            Controls.Add(txtSupplierName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnExit);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SupplierManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SupplierManagementForm";
            Load += SupplierManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLowStockBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
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
        private Label label6;
        private TextBox txtSupplierName;
        private TextBox txtContactPerson;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnAddSupplier;
        private Button btnUpdateSupplier;
        private Button btnDeleteSupplier;
        private Button btnClear;
        private DataGridView dgvLowStockBooks;
        private Button btnRestock;
        private Label label7;
        private DataGridView dgvSuppliers;
    }
}