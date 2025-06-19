using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class Account
{
    public string? FullName { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public int? Role { get; set; }

    public int? Status { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ExportReceipt> ExportReceipts { get; set; } = new List<ExportReceipt>();

    public virtual ICollection<ImportReceipt> ImportReceipts { get; set; } = new List<ImportReceipt>();
}
