using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class ExportReceiptRepository
    {
        private ClothingWarehouseManagementContext _context = new();

        public List<ExportReceipt> GetListExportReceipt()
        {
            return _context.ExportReceipts.Include(x => x.CreatedByNavigation).Include(x => x.Customer).Include(x => x.ExportReceiptDetails).ToList();
        }
        public void AddExportRecept(ExportReceipt er)
        {
            foreach (var detail in er.ExportReceiptDetails)
            {
                if (detail.Product != null)
                {
                    detail.Product = null;
                }
            }
            _context.ExportReceipts.Add(er);
            _context.SaveChanges();
        }

        public int GetLastExportId()
        {
            return _context.ExportReceipts.OrderByDescending(x => x.ReceiptId).Select(x => x.ReceiptId).FirstOrDefault();
        }

        public List<ExportReceiptDetail> GetExportReceiptDetails(int receptId)
        {
            return _context.ExportReceiptDetails.Include(x => x.Product).Where(x => x.ReceiptId == receptId).ToList();
        }

        public List<SalesReport> GetSalesReport()
        {
            var capitalData = _context.ImportReceipts
                .Select(ir => new {
                    Date = ir.CreatedAt.Value,
                    Capital = ir.TotalAmount,
                    Revenue = 0.0,
                    CostOfGoodsSold = 0.0
                });

            var salesData = _context.ExportReceipts
                .Select(er => new {
                    Date = er.CreatedAt,
                    Capital = 0.0,
                    Revenue = er.TotalAmount,
                    CostOfGoodsSold = er.ExportReceiptDetails.Sum(d => (d.Quantity ?? 0) * (d.BasePriceAtExport ?? 0))
                });

            var reportQuery = capitalData.Concat(salesData)
                .GroupBy(x => x.Date)
                .Select(g => new SalesReport
                {
                    Date = g.Key,
                    Capital = g.Sum(item => item.Capital),
                    Revenue = g.Sum(item => item.Revenue),
                    Profit = g.Sum(item => item.Revenue) - g.Sum(item => item.CostOfGoodsSold)
                })
                .OrderBy(r => r.Date);

            return reportQuery.ToList();
        }
    }
}
