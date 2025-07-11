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
            return _context.ImportReceipts.Include(ir => ir.Supplier).Include(ir => ir.CreatedByNavigation).Include(ir => ir.ImportReceiptDetails).ToList();
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

        public void UpdatePriceOfProductAfterImport()
        {
            var listImportReceipt = GetListImportRecept();
            foreach (var receipt in listImportReceipt)
            {
                foreach (var detail in receipt.ImportReceiptDetails)
                {
                    if (detail.Quantity <= 0)
                    {
                        continue;
                    }

                    double importPricePerUnit = (double)(detail.UnitPrice / detail.Quantity);

                    double newSellingPrice = importPricePerUnit * 1.10;

                    var productToUpdate = _context.Products.FirstOrDefault(x => x.ProductId == detail.ProductId);

                    if (productToUpdate != null)
                    {
                        productToUpdate.Price = newSellingPrice;
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Product with ID {detail.ProductId} not found.");
                    }
                }
            }
        }

        public int GetLastImportId()
        {
            return _context.ImportReceipts.OrderByDescending(x => x.ReceiptId).Select(x => x.ReceiptId).FirstOrDefault();
        }

        public List<ImportReceiptDetail> GetImportReceiptDetails(int receptId)
        {
            return _context.ImportReceiptDetails.Include(x => x.Product).Where(x => x.ReceiptId == receptId).ToList();
        }
    }
}
