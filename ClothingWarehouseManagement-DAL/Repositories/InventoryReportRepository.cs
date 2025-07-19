using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class InventoryReportRepository
    {
        private ClothingWarehouseManagementContext _context = new();

        public List<InventoryReport> InventoryReports(DateOnly fromDate, DateOnly toDate)
        {
            // Tính tồn đầu kỳ: (Tổng nhập trước fromDate) - (Tổng xuất trước fromDate)
            // TỒN CUỐI KỲ = Tồn đầu kỳ + Nhập trong kỳ - Xuất trong kỳ

            var importData = _context.ImportReceiptDetails
                .GroupBy(x => x.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ImportBefore = g.Where(x => x.Receipt.CreatedAt < fromDate).Sum(d => d.Quantity ?? 0),
                    ImportDuring = g.Where(x => x.Receipt.CreatedAt >= fromDate && x.Receipt.CreatedAt <= toDate).Sum(x => x.Quantity ?? 0)
                }).ToList();

            
            var exportData = _context.ExportReceiptDetails
                .GroupBy(x => x.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ExportBefore = g.Where(x => x.Receipt.CreatedAt < fromDate).Sum(x => x.Quantity ?? 0),
                    ExportDuring = g.Where(x => x.Receipt.CreatedAt >= fromDate && x.Receipt.CreatedAt <= toDate).Sum(x => x.Quantity ?? 0)
                }).ToList();

            var reportList = new List<InventoryReport>();

            foreach (var product in _context.Products)
            {
                // Lấy dữ liệu nhập/xuất đã tính toán sẵn cho sản phẩm hiện tại
                var pImport = importData.FirstOrDefault(i => i.ProductId == product.ProductId);
                var pExport = exportData.FirstOrDefault(e => e.ProductId == product.ProductId);

                // Tính toán các giá trị
                int beginInventory = (pImport?.ImportBefore ?? 0) - (pExport?.ExportBefore ?? 0);
                int inInventory = pImport?.ImportDuring ?? 0;
                int outInventory = pExport?.ExportDuring ?? 0;
                int endInventory = beginInventory + inInventory - outInventory;

                // Chỉ thêm vào báo cáo nếu sản phẩm có giao dịch hoặc còn tồn kho
                if (beginInventory != 0 || inInventory != 0 || outInventory != 0 || endInventory != 0)
                {
                    reportList.Add(new InventoryReport
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        BeginInventory = beginInventory,
                        In = inInventory,
                        Out = outInventory,
                        EndInventory = endInventory
                    });
                }
            }
            return reportList;
        }
    }
}
