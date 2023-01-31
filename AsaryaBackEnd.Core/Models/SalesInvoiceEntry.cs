using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsaryaBackEnd.Core.Models
{
    public class SalesInvoiceEntry
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(SalesInvoice.SalesInvoiceEntry))]
        public virtual SalesInvoice Invoice { get; set; }
        public virtual Item Item { get; set; }
    }
}
