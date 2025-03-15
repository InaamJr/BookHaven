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
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardRepository _dashboardRepository;

        public AdminDashboardService(IAdminDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public decimal GetTotalSales() => _dashboardRepository.GetTotalSales();
        public int GetTotalOrders() => _dashboardRepository.GetTotalOrders();
        public int GetTotalCustomers() => _dashboardRepository.GetTotalCustomers();
        public int GetTotalBooksInStock() => _dashboardRepository.GetTotalBooksInStock();
        public List<SalesReportModel> GetMonthlySales() => _dashboardRepository.GetMonthlySales();
        public List<BookSalesModel> GetBestSellingBooks() => _dashboardRepository.GetBestSellingBooks();
        public List<LowStockBookModel> GetLowStockBooks() => _dashboardRepository.GetLowStockBooks();
        public List<StaffPerformanceModel> GetStaffPerformance() => _dashboardRepository.GetStaffPerformance();
        public List<CustomerActivityModel> GetCustomerActivity()
        {
            return _dashboardRepository.GetCustomerActivity();
        }
    }
}
