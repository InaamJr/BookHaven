using System;
using System.Windows.Forms;
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;
using System.Collections.Generic;
using static BookHaven.Forms.LoginForm;
using BookHaven.Business;
using BookHaven.Business.Interfaces;


namespace BookHaven.Forms
{
    public partial class BookManagementForm : Form
    {
        private readonly BookService _bookService;
        private readonly SupplierService _supplierService;
        private Guid _selectedBookId;  // Stores selected book ID for update/delete

        public BookManagementForm()
        {
            InitializeComponent();
            _bookService = new BookService(new BookRepository());
            _supplierService = new SupplierService(new SupplierRepository());
            LoadBooks();
            LoadSuppliers();
        }

        private void BookManagementForm_Load(object sender, EventArgs e)
        {

        }

        // Load Books into DataGridView
        private void LoadBooks()
        {
            dgvBooks.AutoGenerateColumns = false;  // Prevents auto columns from being removed
            dgvBooks.DataSource = null;

            List<BookModel> books = _bookService.GetAllBooks();
            dgvBooks.DataSource = books;
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = _supplierService.GetAllSuppliers(); // Fetch all suppliers

                if (suppliers != null && suppliers.Count > 0)
                {
                    cmbSupplier.DataSource = suppliers;
                    cmbSupplier.DisplayMember = "Name";  // Show Supplier Name
                    cmbSupplier.ValueMember = "SupplierID"; // Store SupplierID
                }
                else
                {
                    cmbSupplier.DataSource = null;
                    MessageBox.Show("No suppliers available. Please add a supplier first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Add New Book
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Invalid price format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("Invalid stock quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BookModel newBook = new BookModel
                {
                    BookID = Guid.NewGuid(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Genre = txtGenre.Text.Trim(),
                    ISBN = txtISBN.Text.Trim(),
                    Price = price,
                    StockQuantity = stock,
                    SupplierID = (Guid)cmbSupplier.SelectedValue,
                    UserID = Session.LoggedInUserID
                };


                _bookService.AddBook(newBook);
                MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();  // Refresh grid
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update Book
        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBookId == Guid.Empty)
                {
                    MessageBox.Show("Please select a book to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Session.LoggedInUserID == Guid.Empty)
                {
                    MessageBox.Show("User ID is invalid. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BookModel updatedBook = new BookModel
                {
                    BookID = _selectedBookId,
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = txtGenre.Text,
                    ISBN = txtISBN.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    StockQuantity = int.Parse(txtStock.Text)
                };

                _bookService.UpdateBook(updatedBook);
                MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete Book
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedBookId == Guid.Empty)
                {
                    MessageBox.Show("Please select a book to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    _bookService.DeleteBook(_selectedBookId);
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear Input Fields
        private void ClearFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtISBN.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            _selectedBookId = Guid.Empty;
        }

        // Select Book from DataGridView
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].Cells["BookID"].Value != null)  // Ensure a valid row is selected
            {
                try
                {
                    DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                    // Assign BookID correctly
                    _selectedBookId = (Guid)row.Cells["BookID"].Value;

                    // Populate textboxes safely
                    txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? string.Empty;
                    txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? string.Empty;
                    txtGenre.Text = row.Cells["Genre"].Value?.ToString() ?? string.Empty;
                    txtISBN.Text = row.Cells["ISBN"].Value?.ToString() ?? string.Empty;
                    txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "0";
                    txtStock.Text = row.Cells["StockQuantity"].Value?.ToString() ?? "0";

                    MessageBox.Show("Book selected successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();  
            MainForm mainForm = new MainForm(Session.LoggedInUserRole); 
            mainForm.Show();  
        }
    }
}
