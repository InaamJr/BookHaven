using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public Guid CustomerID { get; set; }  // Customer making the order
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }  // Pending, Completed, Cancelled
        public string PaymentStatus { get; set; }  // Pending, Completed, Cancelled
        public string DeliveryType { get; set; }  // Pickup, Delivery
        public DateTime ExpectedDeliveryDate { get; set; }
        public Guid UserID { get; set; }  // User who placed the order
    }
}
