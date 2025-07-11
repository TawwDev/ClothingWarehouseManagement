using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            UpdatePriceOfProductAfterImport(ir.ReceiptId);
        }

        public void UpdatePriceOfProductAfterImport(int receiptId)
        {
            var importDetails = _context.ImportReceiptDetails.Where(x => x.ReceiptId == receiptId).ToList();
            if (!importDetails.Any())
            {
                return;
            }
            foreach (var detail in importDetails)
            {
                var productToUpdate = _context.Products.Where(x => x.ProductId == detail.ProductId).Include(x => x.Category).FirstOrDefault();
                if (productToUpdate == null || productToUpdate.Category == null || detail.Quantity <= 0 || detail.UnitPrice < 0)
                {
                    continue;
                }
                double oldStockValue = productToUpdate.BasePrice * productToUpdate.Quantity;
                double newStockValue = (double)(detail.UnitPrice * detail.Quantity);
                int totalNewQuantity = (int)(productToUpdate.Quantity + detail.Quantity);
                double newAverageBasePrice = 0;
                if (totalNewQuantity > 0)
                {
                    newAverageBasePrice = Math.Round((oldStockValue + newStockValue) / totalNewQuantity / 1000) * 1000;
                }
                productToUpdate.BasePrice = newAverageBasePrice;
                var profitMargin = productToUpdate.Category.ProfitMargin;
                var newSellingPrice = productToUpdate.BasePrice * (1.0 + profitMargin);
                productToUpdate.Price = Math.Round(newSellingPrice / 1000) * 1000;
                productToUpdate.Quantity += (int)detail.Quantity;
                _context.Products.Update(productToUpdate);
            }
            _context.SaveChanges();

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
