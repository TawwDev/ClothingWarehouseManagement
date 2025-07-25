﻿using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class ImportReceiptDetail
{
    public int ReceiptId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public double? UnitPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ImportReceipt Receipt { get; set; } = null!;
}
