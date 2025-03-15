using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface ISupplierRepository
    {
        List<SupplierModel> GetAllSuppliers();
        void AddSupplier(SupplierModel supplier);
        void UpdateSupplier(SupplierModel supplier);
        void DeleteSupplier(Guid supplierID);
        string GetSupplierEmail(Guid supplierID); // Fetch supplier's email for restocking
    }
}
