using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Business.Interfaces;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // Fetch Sales Report (Filtered by Date Range)
        public List<SalesTransactionReportModel> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            return _reportRepository.GetSalesReport(startDate, endDate);
        }

        // Fetch Inventory Report (Book Stock Levels)
        public List<InventoryReportModel> GetInventoryReport()
        {
            return _reportRepository.GetInventoryReport();
        }

        // Fetch Staff Performance Report
        public List<StaffPerformanceReportModel> GetStaffPerformanceReport()
        {
            return _reportRepository.GetStaffPerformanceReport();
        }

        public void GenerateAndSaveReport(string reportType)
        {
            Guid generatedBy = Session.LoggedInUserID;
            decimal totalSales = 0;
            Guid bestSellingBookId = Guid.Empty;
            string inventoryStatus = "";

            // Map valid report types
            string validReportType = reportType switch
            {
                "Sales Report" => "Daily",   // Match CHECK constraint
                "Inventory Report" => "Weekly",  // Example mapping
                "Staff Performance Report" => "Monthly",  // Example mapping
                _ => throw new ArgumentException("Invalid report type!")
            };

            if (reportType == "Sales Report")
            {
                totalSales = _reportRepository.GetTotalSalesForPeriod(validReportType);
                bestSellingBookId = _reportRepository.GetBestSellingBook();
            }
            else if (reportType == "Inventory Report")
            {
                inventoryStatus = _reportRepository.GetInventoryStatus();
            }

            _reportRepository.SaveGeneratedReport(validReportType, totalSales, bestSellingBookId, inventoryStatus, generatedBy);
        }
    }
}
