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
    public partial class CustomerManagementForm : Form
    {
        private readonly CustomerService _customerService;
        private Guid _selectedCustomerId;

        public CustomerManagementForm()
        {
            InitializeComponent();
            _customerService = new CustomerService(new CustomerRepository());
            LoadCustomers();
        }

        // Load Customers into DataGridView
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = null;
            List<CustomerModel> customers = _customerService.GetAllCustomers();
            dgvCustomers.DataSource = customers;
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == Guid.Empty)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _customerService.DeleteCustomer(_selectedCustomerId);
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers(); // Refresh DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerModel newCustomer = new CustomerModel
            {
                CustomerID = Guid.NewGuid(),
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                JoinDate = DateTime.Now,
                UserID = Session.LoggedInUserID
            };

            _customerService.AddCustomer(newCustomer);
            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCustomers();
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

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                _selectedCustomerId = (Guid)row.Cells["CustomerID"].Value;
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (_selectedCustomerId == Guid.Empty)
            {
                MessageBox.Show("Please select a customer to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CustomerModel updatedCustomer = new CustomerModel
                {
                    CustomerID = _selectedCustomerId,
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                _customerService.UpdateCustomer(updatedCustomer);
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
