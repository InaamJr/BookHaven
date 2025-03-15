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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // Get All Suppliers
        public List<SupplierModel> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        // Add Supplier
        public void AddSupplier(SupplierModel supplier)
        {
            _supplierRepository.AddSupplier(supplier);
        }

        // Update Supplier
        public void UpdateSupplier(SupplierModel supplier)
        {
            _supplierRepository.UpdateSupplier(supplier);
        }

        // Delete Supplier
        public void DeleteSupplier(Guid supplierID)
        {
            _supplierRepository.DeleteSupplier(supplierID);
        }

        // Send Restock Request (Email Simulation)
        public void SendRestockRequest(Guid bookID, string bookTitle, int restockQuantity, Guid supplierID)
        {
            string supplierEmail = _supplierRepository.GetSupplierEmail(supplierID);
            if (string.IsNullOrEmpty(supplierEmail))
            {
                throw new Exception("Supplier email not found.");
            }

            // Simulate sending an email (real implementation would use SMTP)
            Console.WriteLine($"📩 Email sent to {supplierEmail}:");
            Console.WriteLine($"Subject: Restock Request for {bookTitle}");
            Console.WriteLine($"Message: Please restock {restockQuantity} units of {bookTitle} (Book ID: {bookID}).");
        }
    }
}
