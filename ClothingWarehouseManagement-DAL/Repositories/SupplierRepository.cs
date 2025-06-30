using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class SupplierRepository
    {
        private CWMContext _context = new CWMContext();

        public List<Supplier> GetListSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(Supplier supplier, List<ImportReceipt> importReceipts)
        {
            _context.RemoveRange(importReceipts);
            _context.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
