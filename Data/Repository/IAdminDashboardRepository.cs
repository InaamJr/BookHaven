using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IAdminDashboardRepository
    {
        decimal GetTotalSales();
        int GetTotalOrders();
        int GetTotalCustomers();
        int GetTotalBooksInStock();
        List<SalesReportModel> GetMonthlySales();
        List<BookSalesModel> GetBestSellingBooks();
        List<LowStockBookModel> GetLowStockBooks();
        List<StaffPerformanceModel> GetStaffPerformance();
        List<CustomerActivityModel> GetCustomerActivity();
    }
}
