using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface ISupplierService
    {
        List<SupplierModel> GetAllSuppliers();
        void AddSupplier(SupplierModel supplier);
        void UpdateSupplier(SupplierModel supplier);
        void DeleteSupplier(Guid supplierID);
        void SendRestockRequest(Guid bookID, string bookTitle, int restockQuantity, Guid supplierID);
    }
}
