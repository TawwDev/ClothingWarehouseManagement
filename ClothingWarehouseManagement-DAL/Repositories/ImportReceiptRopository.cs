using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class ImportReceiptRopository
    {
        private ClothingWarehouseManagementContext _context = new();

        public List<ImportReceipt> GetListImportRecept()
        {
            return _context.ImportReceipts.Include(ir => ir.Supplier).Include(ir => ir.CreatedByNavigation).ToList();
        }
        public void AddImportRecept(ImportReceipt ir)
        {
            foreach (var detail in ir.ImportReceiptDetails)
            {
                if (detail.Product != null)
                {
                    detail.Product = null;
                }
            }
            _context.ImportReceipts.Add(ir);
            _context.SaveChanges();
        }

        public int GetLastImportId()
        {
            return _context.ImportReceipts.OrderByDescending(x => x.ReceiptId).Select(x => x.ReceiptId).FirstOrDefault();
        }
    }
}
