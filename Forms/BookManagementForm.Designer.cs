namespace BookHaven.Forms
{
    partial class BookManagementForm
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
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtGenre = new TextBox();
            txtISBN = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvBooks = new DataGridView();
            BookID = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Author = new DataGridViewTextBoxColumn();
            Genre = new DataGridViewTextBoxColumn();
            ISBN = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            StockQuantity = new DataGridViewTextBoxColumn();
            SupplierID = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            btnAddBook = new Button();
            btnUpdateBook = new Button();
            btnDeleteBook = new Button();
            btnExit = new Button();
            label7 = new Label();
            cmbSupplier = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("SF Pro Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ControlText;
            lblTitle.Location = new Point(365, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(368, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Book Inventory Management";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(207, 157);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(169, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(207, 202);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(169, 23);
            txtAuthor.TabIndex = 2;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(207, 251);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(169, 23);
            txtGenre.TabIndex = 3;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(207, 301);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(169, 23);
            txtISBN.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(207, 351);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(169, 23);
            txtPrice.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(207, 400);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(169, 23);
            txtStock.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label1.Location = new Point(59, 157);
            label1.Name = "label1";
            label1.Size = new Size(82, 19);
            label1.TabIndex = 7;
            label1.Text = "Book Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label2.Location = new Point(59, 202);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 8;
            label2.Text = "Author Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label3.Location = new Point(59, 251);
            label3.Name = "label3";
            label3.Size = new Size(94, 19);
            label3.TabIndex = 9;
            label3.Text = "Book Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label4.Location = new Point(59, 301);
            label4.Name = "label4";
            label4.Size = new Size(44, 19);
            label4.TabIndex = 10;
            label4.Text = "ISBN";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label5.Location = new Point(59, 351);
            label5.Name = "label5";
            label5.Size = new Size(47, 19);
            label5.TabIndex = 11;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label6.Location = new Point(59, 400);
            label6.Name = "label6";
            label6.Size = new Size(119, 19);
            label6.TabIndex = 12;
            label6.Text = "Stock Quantity";
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = SystemColors.ActiveCaption;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Columns.AddRange(new DataGridViewColumn[] { BookID, Title, Author, Genre, ISBN, Price, StockQuantity, SupplierID, UserID });
            dgvBooks.Location = new Point(446, 120);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.Size = new Size(595, 455);
            dgvBooks.TabIndex = 13;
            dgvBooks.CellClick += dgvBooks_CellClick;
            // 
            // BookID
            // 
            BookID.DataPropertyName = "BookID";
            BookID.HeaderText = "BookID";
            BookID.Name = "BookID";
            // 
            // Title
            // 
            Title.DataPropertyName = "Title";
            Title.HeaderText = "Title";
            Title.Name = "Title";
            // 
            // Author
            // 
            Author.DataPropertyName = "Author";
            Author.HeaderText = "Author";
            Author.Name = "Author";
            // 
            // Genre
            // 
            Genre.DataPropertyName = "Genre";
            Genre.HeaderText = "Genre";
            Genre.Name = "Genre";
            // 
            // ISBN
            // 
            ISBN.DataPropertyName = "ISBN";
            ISBN.HeaderText = "ISBN";
            ISBN.Name = "ISBN";
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Price";
            Price.Name = "Price";
            // 
            // StockQuantity
            // 
            StockQuantity.DataPropertyName = "StockQuantity";
            StockQuantity.HeaderText = "StockQuantity";
            StockQuantity.Name = "StockQuantity";
            // 
            // SupplierID
            // 
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.HeaderText = "SupplierID";
            SupplierID.Name = "SupplierID";
            // 
            // UserID
            // 
            UserID.DataPropertyName = "UserID";
            UserID.HeaderText = "UserID";
            UserID.Name = "UserID";
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.White;
            btnAddBook.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnAddBook.ForeColor = Color.Black;
            btnAddBook.Location = new Point(59, 540);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(96, 35);
            btnAddBook.TabIndex = 14;
            btnAddBook.Text = "ADD BOOK";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnUpdateBook
            // 
            btnUpdateBook.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnUpdateBook.Location = new Point(171, 540);
            btnUpdateBook.Name = "btnUpdateBook";
            btnUpdateBook.Size = new Size(96, 35);
            btnUpdateBook.TabIndex = 15;
            btnUpdateBook.Text = "UPDATE";
            btnUpdateBook.UseVisualStyleBackColor = true;
            btnUpdateBook.Click += btnUpdateBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.BackColor = Color.Firebrick;
            btnDeleteBook.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnDeleteBook.ForeColor = Color.White;
            btnDeleteBook.Location = new Point(280, 540);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(96, 35);
            btnDeleteBook.TabIndex = 16;
            btnDeleteBook.Text = "DELETE";
            btnDeleteBook.UseVisualStyleBackColor = false;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("SF Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(27, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 37);
            btnExit.TabIndex = 17;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label7.Location = new Point(59, 451);
            label7.Name = "label7";
            label7.Size = new Size(87, 19);
            label7.TabIndex = 19;
            label7.Text = "Supplier ID";
            // 
            // cmbSupplier
            // 
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(207, 451);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(169, 23);
            cmbSupplier.TabIndex = 20;
            // 
            // BookManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1094, 626);
            Controls.Add(cmbSupplier);
            Controls.Add(label7);
            Controls.Add(btnExit);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnUpdateBook);
            Controls.Add(btnAddBook);
            Controls.Add(dgvBooks);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtISBN);
            Controls.Add(txtGenre);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BookManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookManagementForm";
            Load += BookManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtGenre;
        private TextBox txtISBN;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvBooks;
        private Button btnAddBook;
        private Button btnUpdateBook;
        private Button btnDeleteBook;
        private DataGridViewTextBoxColumn BookID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Author;
        private DataGridViewTextBoxColumn Genre;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn StockQuantity;
        private DataGridViewTextBoxColumn SupplierID;
        private DataGridViewTextBoxColumn UserID;
        private Button btnExit;
        private Label label7;
        private ComboBox cmbSupplier;
    }
}