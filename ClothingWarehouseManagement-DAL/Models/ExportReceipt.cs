using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class ExportReceipt
{
    public int ReceiptId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int? CustomerId { get; set; }

    public double TotalAmount { get; set; }

    public virtual Account CreatedByNavigation { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<ExportReceiptDetail> ExportReceiptDetails { get; set; } = new List<ExportReceiptDetail>();
}
