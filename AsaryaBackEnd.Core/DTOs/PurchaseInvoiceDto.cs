using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaryaBackEnd.Core.DTOs
{
    public class PurchaseInvoiceDto
    {
        public int Id { get; init; }
        public int Number { get; init; }
        public int CustomerId { get; init; }
        public decimal? TotalAmount { get; init; }
        public decimal? Discount { get; init; }
        public string? Remarks { get; init; }
        public InvoiceStatus Status { get; init; }
        public DateTime EntryDate { get; init; }
        public ICollection<PurchaseInvoiceEntryDto> PurchaseInvoiceEntry { get; init; }
    }
}
