﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaryaBackEnd.Core.DTOs
{
    public class PurchaseInvoiceEntryDto
    {
        public int Id { get; init; }
        public int InvoiceId { get; init; }
        public int ItemId { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }
}