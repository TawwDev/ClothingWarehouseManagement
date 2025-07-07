using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class SupplierRepository
    {
        private ClothingWarehouseManagementContext _context = new ClothingWarehouseManagementContext();

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

        public void DeleteSupplier(Supplier supplier)
        {
            Supplier s = _context.Suppliers.Include(s => s.ImportReceipts).FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
            s.ImportReceipts.Clear();
            _context.Remove(s);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int id)
        {
            return _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);
        }
    }
}
