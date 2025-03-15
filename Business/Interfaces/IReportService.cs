using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface IReportService
    {
        List<SalesTransactionReportModel> GetSalesReport(DateTime startDate, DateTime endDate);
        List<InventoryReportModel> GetInventoryReport();
        List<StaffPerformanceReportModel> GetStaffPerformanceReport();
        void GenerateAndSaveReport(string reportType);
    }
}
