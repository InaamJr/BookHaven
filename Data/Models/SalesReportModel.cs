using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class SalesReportModel
    {
        public string Month { get; set; }  // Format: "YYYY-MM"
        public decimal TotalSales { get; set; }
    }
}
