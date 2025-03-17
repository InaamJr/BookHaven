using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BookHaven.Business;
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private readonly IAdminDashboardService _dashboardService;

        public AdminDashboardForm(IAdminDashboardService dashboardService)
        {
            InitializeComponent();
            _dashboardService = dashboardService;

            LoadDashboardData();
            LoadStaffPerformance();
            GenerateBestSellingBooksChart();
            GenerateMonthlySalesChart();
            LoadCustomerActivity();
        }

        public AdminDashboardForm() : this(new AdminDashboardService(new AdminDashboardRepository()))
        {
        }

        // Load Dashboard Data
        private void LoadDashboardData()
        {
            Console.WriteLine("DEBUG: Loading Dashboard Data...");

            try
            {
                decimal totalSales = _dashboardService.GetTotalSales();
                int totalOrders = _dashboardService.GetTotalOrders();
                int totalCustomers = _dashboardService.GetTotalCustomers();
                int totalBooks = _dashboardService.GetTotalBooksInStock();
                List<BookSalesModel> bestSellingBooks = _dashboardService.GetBestSellingBooks();
                List<StaffPerformanceModel> staffPerformance = _dashboardService.GetStaffPerformance();
                List<LowStockBookModel> lowStockBooks = _dashboardService.GetLowStockBooks();

                if (lowStockBooks.Count > 0)
                {
                    lblLowStockBooks.Text = string.Join(", ", lowStockBooks.Select(b => $"{b.Title} ({b.StockQuantity})"));
                }
                else
                {
                    lblLowStockBooks.Text = "None";
                }

                // Debug Output to Console
                //Console.WriteLine($"DEBUG: Total Sales: {totalSales}");
                //Console.WriteLine($"DEBUG: Total Orders: {totalOrders}");
                //Console.WriteLine($"DEBUG: Total Customers: {totalCustomers}");
                //Console.WriteLine($"DEBUG: Total Books In Stock: {totalBooks}");
                //Console.WriteLine($"DEBUG: Best-Selling Books Count: {bestSellingBooks.Count}");
                //Console.WriteLine($"DEBUG: Staff Performance Count: {staffPerformance.Count}");

                // Set values to labels
                lblTotalSales.Text = $"{totalSales:C}";
                lblTotalOrders.Text = $"{totalOrders}";
                lblBestSellingBook.Text = bestSellingBooks.Count > 0 ? $"{bestSellingBooks[0].BookTitle}" : "Best-Selling Book: None";

                // Load Staff Performance Data
                dgvStaffPerformance.DataSource = staffPerformance;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                MessageBox.Show("Error loading dashboard data. Check console logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            if (Session.LoggedInUserRole != "Admin")
            {
                MessageBox.Show("Access Denied: Only Admins can view the dashboard!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Generate Monthly Sales Chart Dynamically
        private void GenerateMonthlySalesChart()
        {
            List<SalesReportModel> monthlySales = _dashboardService.GetMonthlySales();

            Chart chartMonthlySales = new Chart
            {
                Parent = this,
                Size = new Size(350, 250),  // Set chart size
                Location = new Point(600, 445),  // Place below Best-Selling Books chart
                BackColor = Color.Transparent
            };

            ChartArea chartArea = new ChartArea("SalesChartArea");
            chartMonthlySales.ChartAreas.Add(chartArea);

            Series salesSeries = new Series("Monthly Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue
            };

            foreach (var data in monthlySales)
            {
                salesSeries.Points.AddXY(data.Month, data.TotalSales);
            }

            chartMonthlySales.Series.Add(salesSeries);
            this.Controls.Add(chartMonthlySales);
        }

        // Generate Best-Selling Books Chart Dynamically
        private void GenerateBestSellingBooksChart()
        {
            List<BookSalesModel> bestSellingBooks = _dashboardService.GetBestSellingBooks();

            Chart chartBestSellingBooks = new Chart
            {
                Parent = this,
                Size = new Size(350, 250),  // Set chart size
                Location = new Point(600, 150),  // Position on the right side, below the header
                BackColor = Color.Transparent
            };

            ChartArea chartArea = new ChartArea("BookSalesChartArea");
            chartBestSellingBooks.ChartAreas.Add(chartArea);

            Series bookSalesSeries = new Series("Best-Selling Books")
            {
                ChartType = SeriesChartType.Pie
            };

            foreach (var book in bestSellingBooks)
            {
                bookSalesSeries.Points.AddXY(book.BookTitle, book.SalesCount);
            }

            chartBestSellingBooks.Series.Add(bookSalesSeries);
            this.Controls.Add(chartBestSellingBooks);
        }


        // Load Staff Performance into DataGridView
        private void LoadStaffPerformance()
        {
            var staffPerformance = _dashboardService.GetStaffPerformance();

            if (staffPerformance == null || staffPerformance.Count == 0)
            {
                Console.WriteLine("DEBUG: No staff performance data retrieved.");
                return;
            }

            dgvStaffPerformance.DataSource = staffPerformance;
            dgvStaffPerformance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaffPerformance.Refresh();
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

        private void dgvCustomerActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadCustomerActivity()
        {
            var customerActivity = _dashboardService.GetCustomerActivity();

            if (customerActivity == null || customerActivity.Count == 0)
            {
                Console.WriteLine("DEBUG: No customer activity data retrieved.");
                return;
            }

            Console.WriteLine($"DEBUG: DataGridView Binding - {customerActivity.Count} rows");

            dgvCustomerActivity.DataSource = customerActivity;
            dgvCustomerActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerActivity.Refresh();
        }

        private void btnBusinessSettings_Click(object sender, EventArgs e)
        {
            BusinessSettingsForm businessSettingsForm = new BusinessSettingsForm();
            businessSettingsForm.ShowDialog();
        }
    }
}
