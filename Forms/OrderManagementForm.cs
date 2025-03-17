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
    public partial class OrderManagementForm : Form
    {
        private readonly OrderService _orderService;
        private List<OrderDetailsModel> _orderDetails = new List<OrderDetailsModel>();
        private decimal totalAmount = 0;
        private int _selectedOrderID;


        public OrderManagementForm()
        {
            InitializeComponent();
            _orderService = new OrderService(new OrderRepository(), new CustomerRepository(), new BookRepository());

            LoadCustomers();
            LoadBooks();
            LoadOrders();
            InitializeOrderDetailsGrid();
        }

        // Load Customers into Dropdown
        private void LoadCustomers()
        {
            var customers = _orderService.GetAllCustomers();
            cmbCustomers.DataSource = customers;
            cmbCustomers.DisplayMember = "Name";  // Show Name
            cmbCustomers.ValueMember = "CustomerID";  // Store ID
        }

        // Load Books into Dropdown
        private void LoadBooks()
        {
            var books = _orderService.GetAllBooks();
            cmbBooks.DataSource = books;
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "BookID";
        }

        private void InitializeOrderDetailsGrid()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add("BookTitle", "Book Title");
            dgvOrderDetails.Columns.Add("Quantity", "Quantity");
            dgvOrderDetails.Columns.Add("PricePerUnit", "Price Per Unit");
            dgvOrderDetails.Columns.Add("SubTotal", "Subtotal");

            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Load Orders into Grid
        private void LoadOrders()
        {
            dgvOrders.DataSource = null;
            var orders = _orderService.GetAllOrders();

            var formattedOrders = orders.Select(order => new
            {
                order.OrderID,
                order.CustomerID,
                CustomerName = _orderService.GetCustomerNameById(order.CustomerID),
                order.OrderDate,
                order.TotalAmount,
                order.OrderStatus,
                order.PaymentStatus,
                order.DeliveryType,
                order.ExpectedDeliveryDate,
                order.UserID
            }).ToList();

            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Set before binding
            dgvOrders.DataSource = formattedOrders;
        }


        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            InitializeOrderDetailsGrid();
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BookModel selectedBook = (BookModel)cmbBooks.SelectedItem;

            // Check stock availability before adding to order
            if (quantity > selectedBook.StockQuantity)
            {
                MessageBox.Show($"Insufficient stock! Only {selectedBook.StockQuantity} left in stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = selectedBook.Price * quantity;

            OrderDetailsModel newDetail = new OrderDetailsModel
            {
                BookID = selectedBook.BookID,
                BookTitle = selectedBook.Title,
                Quantity = quantity,
                PricePerUnit = selectedBook.Price,
                SubTotal = subTotal
            };

            _orderDetails.Add(newDetail);
            dgvOrderDetails.Rows.Add(selectedBook.Title, quantity, selectedBook.Price, subTotal);

            totalAmount += subTotal;
            lblTotalAmount.Text = totalAmount.ToString("C");
        }

        // Refresh Order Details Grid
        private void RefreshOrderDetailsGrid()
        {
            dgvOrderDetails.DataSource = null;  // Remove existing data
            dgvOrderDetails.Rows.Clear();       // Clear existing rows
            dgvOrderDetails.Columns.Clear();    // clear existing columns to prevent duplication

            // Ensure columns are only added once
            dgvOrderDetails.AutoGenerateColumns = false;

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Book Title", DataPropertyName = "BookTitle" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Quantity", DataPropertyName = "Quantity" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { Name = "PricePerUnit", HeaderText = "Price Per Unit", DataPropertyName = "PricePerUnit" });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn { Name = "SubTotal", HeaderText = "Subtotal", DataPropertyName = "SubTotal" });

            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set the data source only after clearing columns
            dgvOrderDetails.DataSource = _orderDetails;
        }



        // Update Total Amount
        private void UpdateTotalAmount()
        {
            decimal totalAmount = _orderDetails.Sum(od => od.SubTotal);
            lblTotalAmount.Text = totalAmount.ToString("C");  // Display currency format
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_orderDetails.Count == 0)
            {
                MessageBox.Show("Please add at least one book to the order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CustomerModel selectedCustomer = (CustomerModel)cmbCustomers.SelectedItem;

            OrderModel newOrder = new OrderModel
            {
                CustomerID = (Guid)cmbCustomers.SelectedValue,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                OrderStatus = cmbOrderStatus.SelectedItem.ToString(),
                PaymentStatus = cmbPaymentStatus.SelectedItem.ToString(),
                DeliveryType = cmbDeliveryType.SelectedItem.ToString(),
                ExpectedDeliveryDate = dtpExpectedDeliveryDate.Value,
                UserID = Session.LoggedInUserID
            };

            _orderService.CreateOrder(newOrder, _orderDetails);
            MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrders();
            ClearOrderForm();
        }

        //Clear Form Fields
        private void ClearOrderForm()
        {
            if (dgvOrders.SelectedRows.Count > 0)  // Check if a row is selected
            {
                _selectedOrderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            }
            else
            {
                _selectedOrderID = 0;  // Reset to default value if no selection
            }

            cmbCustomers.SelectedIndex = -1;
            cmbBooks.SelectedIndex = -1;
            txtQuantity.Clear();
            _orderDetails.Clear();
            RefreshOrderDetailsGrid();
            UpdateTotalAmount();
        }


        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.SelectedRows.Count > 0)  // Check if a row is selected
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];  // Get the row based on clicked index

                // Ensure "OrderID" exists in DataGridView before accessing it
                if (row.Cells["OrderID"].Value != null)
                {
                    _selectedOrderID = Convert.ToInt32(row.Cells["OrderID"].Value);  // Convert OrderID safely

                    // Populate Order Details
                    if (row.Cells["CustomerID"] != null)
                    {
                        cmbCustomers.SelectedValue = row.Cells["CustomerID"].Value;
                    }

                    cmbOrderStatus.SelectedItem = row.Cells["OrderStatus"].Value.ToString();
                    cmbPaymentStatus.SelectedItem = row.Cells["PaymentStatus"].Value.ToString();
                    cmbDeliveryType.SelectedItem = row.Cells["DeliveryType"].Value.ToString();
                    dtpExpectedDeliveryDate.Value = (DateTime)row.Cells["ExpectedDeliveryDate"].Value;

                    _orderDetails = _orderService.GetOrderDetails(_selectedOrderID);
                    RefreshOrderDetailsGrid();
                    UpdateTotalAmount();
                }
                else
                {
                    MessageBox.Show("Invalid Order Selection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedOrderID = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            if (_orderDetails.Count == 0)
            {
                MessageBox.Show("Order details cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OrderModel updatedOrder = new OrderModel
            {
                OrderID = _selectedOrderID,
                OrderStatus = cmbOrderStatus.SelectedItem.ToString(),
                PaymentStatus = cmbPaymentStatus.SelectedItem.ToString(),
                DeliveryType = cmbDeliveryType.SelectedItem.ToString(),
                ExpectedDeliveryDate = dtpExpectedDeliveryDate.Value,
                TotalAmount = totalAmount,
                UserID = Session.LoggedInUserID
            };

            _orderService.UpdateOrder(_selectedOrderID, updatedOrder, _orderDetails);
            MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrders();
            ClearOrderForm();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedOrderID = (int)dgvOrders.SelectedRows[0].Cells["OrderID"].Value;
            _orderService.DeleteOrder(_selectedOrderID); 

            MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrders();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            cmbCustomers.SelectedIndex = -1;
            cmbBooks.SelectedIndex = -1;
            txtQuantity.Clear();
            dgvOrderDetails.DataSource = null;
            lblTotalAmount.Text = "$0.00";
            totalAmount = 0;
            _orderDetails.Clear();
        }
    }
}
