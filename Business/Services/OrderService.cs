using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Business.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        // Constructor - Inject Dependencies
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        // Create a New Order
        public int CreateOrder(OrderModel order, List<OrderDetailsModel> orderDetails)
        {
            return _orderRepository.CreateOrder(order, orderDetails);
        }

        // Retrieve All Orders
        public List<OrderModel> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        // Retrieve Order Details by Order ID
        public List<OrderDetailsModel> GetOrderDetails(int orderId)
        {
            return _orderRepository.GetOrderDetails(orderId);
        }

        // Update an Existing Order
        public void UpdateOrder(int orderId, OrderModel updatedOrder, List<OrderDetailsModel> orderDetails)
        {
            _orderRepository.UpdateOrder(orderId, updatedOrder, orderDetails);
        }

        // Delete an Order
        public void DeleteOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }

        // Retrieve All Customers (For Dropdown)
        public List<CustomerModel> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        // Retrieve All Books (For Dropdown)
        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public string GetCustomerNameById(Guid customerId)
        {
            if (customerId == Guid.Empty) return "Unknown"; // Prevent empty GUID issues

            var customer = _customerRepository.GetCustomerById(customerId);
            return customer != null ? customer.Name : "Unknown";  // Check if customer exists
        }
    }
}
