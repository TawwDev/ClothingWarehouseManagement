using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class ImportReceipt
{
    public int ReceiptId { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public int? SupplierId { get; set; }

    public double TotalAmount { get; set; }

    public virtual Account? CreatedByNavigation { get; set; }

    public virtual ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; } = new List<ImportReceiptDetail>();

    public virtual Supplier? Supplier { get; set; }
}
