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
    }
}
