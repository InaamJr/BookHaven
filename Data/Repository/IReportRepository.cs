using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IReportRepository
    {
        // Fetch Sales Report (Filtered by Date Range)
        List<SalesTransactionReportModel> GetSalesReport(DateTime startDate, DateTime endDate);

        // Fetch Inventory Report (Book Stock Levels)
        List<InventoryReportModel> GetInventoryReport();

        // Fetch Staff Performance Report
        List<StaffPerformanceReportModel> GetStaffPerformanceReport();
        decimal GetTotalSalesForPeriod(string reportType);
        List<BookSalesModel> GetBestSellingBooks();
        Guid GetBestSellingBook();
        string GetInventoryStatus();
        void SaveGeneratedReport(string reportType, decimal totalSales, Guid bestSellingBookId, string inventoryStatus, Guid generatedBy);
    }
}
