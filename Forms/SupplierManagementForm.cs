using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Business;
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class SupplierManagementForm : Form
    {
        private readonly SupplierService _supplierService;
        private readonly BookService _bookService;
        private Guid _selectedSupplierID;

        public SupplierManagementForm()
        {
            InitializeComponent();
            _supplierService = new SupplierService(new SupplierRepository());
            _bookService = new BookService(new BookRepository());

            LoadSuppliers();
            LoadLowStockBooks();
        }

        private void SupplierManagementForm_Load(object sender, EventArgs e)
        {
            if (Session.LoggedInUserRole != "Admin")
            {
                MessageBox.Show("Access Denied: Only Admins can manage suppliers!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Load Suppliers into the DataGrid
        private void LoadSuppliers()
        {
            dgvSuppliers.DataSource = _supplierService.GetAllSuppliers();
        }

        // Load Low Stock Books into the DataGrid
        private void LoadLowStockBooks()
        {
            // Fetch low stock books from the BookService
            var lowStockBooks = _bookService.GetLowStockBooks();  // Fetch the data properly

            // Bind data to the DataGridView
            dgvLowStockBooks.DataSource = lowStockBooks;

            // Remove SupplierID column from the table since SupplierName is displayed instead
            if (dgvLowStockBooks.Columns["SupplierID"] != null)
            {
                dgvLowStockBooks.Columns["SupplierID"].Visible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            // Ensure the application exits if no other forms are open
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Please enter a Supplier Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SupplierModel newSupplier = new SupplierModel
            {
                SupplierID = Guid.NewGuid(),
                Name = txtSupplierName.Text,
                ContactPerson = txtContactPerson.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                UserID = Session.LoggedInUserID
            };

            _supplierService.AddSupplier(newSupplier);
            MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSuppliers();
            ClearForm();
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierID == Guid.Empty)
            {
                MessageBox.Show("Please select a supplier to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SupplierModel updatedSupplier = new SupplierModel
            {
                SupplierID = _selectedSupplierID,
                Name = txtSupplierName.Text,
                ContactPerson = txtContactPerson.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                UserID = Session.LoggedInUserID
            };

            _supplierService.UpdateSupplier(updatedSupplier);
            MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSuppliers();
            ClearForm();
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierID == Guid.Empty)
            {
                MessageBox.Show("Please select a supplier to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _supplierService.DeleteSupplier(_selectedSupplierID);
            MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSuppliers();
            ClearForm();
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                _selectedSupplierID = (Guid)row.Cells["SupplierID"].Value;

                txtSupplierName.Text = row.Cells["Name"].Value.ToString();
                txtContactPerson.Text = row.Cells["ContactPerson"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedSupplierID = Guid.Empty;
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (dgvLowStockBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to restock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvLowStockBooks.SelectedRows[0];

            // Null-check before using values
            if (row == null)
            {
                MessageBox.Show("No row selected or data is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fix null reference issues
            RestockBooksForm restockForm = new RestockBooksForm(
                row.Cells["Title"].Value?.ToString() ?? "N/A",
                row.Cells["StockQuantity"].Value != DBNull.Value ? (int)row.Cells["StockQuantity"].Value : 0,
                row.Cells["SupplierID"].Value?.ToString() ?? "Unknown"
            );

            restockForm.ShowDialog();
        }

        private void dgvLowStockBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
