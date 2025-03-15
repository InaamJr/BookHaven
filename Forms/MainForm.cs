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
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class MainForm : Form
    {
        private string _userRole;  // Store the user role

        public MainForm(string userRole)
        {
            InitializeComponent();
            _userRole = userRole;

            System.Diagnostics.Debug.WriteLine($"DEBUG: Received Role in MainForm = {_userRole}");
            ConfigureUIBasedOnRole();  // Call a method to update UI based on role
        }

        private void ConfigureUIBasedOnRole()
        {
            //if (!_userRole.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            //{
            //    btnManageUsers.Enabled = false;
            //    btnGenerateReports.Enabled = false;
            //    btnAdminDashboard.Enabled = false;
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnManageBooks_click(object sender, EventArgs e)
        {
            BookManagementForm bookForm = new BookManagementForm();
            this.Hide();
            bookForm.Show();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            this.Hide();
            customerForm.Show();  // Open the Customer Management Form
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out of System Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderManagementForm orderForm = new OrderManagementForm();
            orderForm.ShowDialog();  // Show the Order Management Form
            this.Show();  // Show MainForm again when Order Form is closed
        }

        private void btnSalesTransaction_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesTransactionForm SalesForm = new SalesTransactionForm();
            SalesForm.ShowDialog();  // Show the Sales Transaction Form
            this.Show();  // Show MainForm again when Sales Form is closed
        }

        private void btnSupplierManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierManagementForm SupplierForm = new SupplierManagementForm();
            SupplierForm.ShowDialog();  // Show the Supplier Management Form
            this.Show();  // Show MainForm again when Supplier Management Form is closed
        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            if (!Session.LoggedInUserRole.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Access Denied: Only Admins has access to the Dashboard!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            AdminDashboardForm AdminForm = new AdminDashboardForm();
            AdminForm.ShowDialog();  // Show the Admin Dashboard Form
            this.Show();  // Show MainForm again when Admin Dashboard Form is closed
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"DEBUG: Checking Role Before Button Click = {Session.LoggedInUserRole}");

            if (!Session.LoggedInUserRole.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Access Denied: Only Admins can manage users!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            IUserService userService = new UserService(new UserRepository());
            ManageUsersForm userForm = new ManageUsersForm(userService);
            userForm.ShowDialog();
            this.Show();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            if (!Session.LoggedInUserRole.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Access Denied: Only Admins can Generate Reports!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            IReportService reportService = new ReportService(new ReportRepository());
            ReportsForm reportsForm = new ReportsForm(reportService);
            reportsForm.ShowDialog();
            this.Show();
        }
    }
}
