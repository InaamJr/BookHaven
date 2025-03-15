using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class SupplierModel
    {
        public Guid SupplierID { get; set; }  // Primary Key
        public string Name { get; set; }  // Supplier Name
        public string ContactPerson { get; set; }  // Contact Person
        public string Email { get; set; }  // Supplier Email
        public string Phone { get; set; }  // Phone Number
        public string Address { get; set; }  // Supplier Address
        public Guid UserID { get; set; }  // Foreign Key - Who added this supplier
    }
}
