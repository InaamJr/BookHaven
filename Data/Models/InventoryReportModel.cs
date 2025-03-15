using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class InventoryReportModel
    {
        public Guid BookID { get; set; }  // Book Unique ID
        public string Title { get; set; }  // Book Name
        public int StockQuantity { get; set; }  // Available Stock
        public decimal Price { get; set; }  // Book Price
        public string SupplierName { get; set; }  // Supplier Name
    }
}
