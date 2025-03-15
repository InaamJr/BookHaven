using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class CustomerModel
    {
        public Guid CustomerID { get; set; }  // Unique ID
        public string Name { get; set; }  // Customer Name
        public string Email { get; set; }  // Email (Unique)
        public string Phone { get; set; }  // Phone Number
        public string Address { get; set; }  // Address
        public DateTime JoinDate { get; set; }  // Date of Joining
        public Guid UserID { get; set; }  // User who added the customer
    }
}
