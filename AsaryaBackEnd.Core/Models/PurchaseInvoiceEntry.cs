using System.ComponentModel.DataAnnotations.Schema;

namespace AsaryaBackEnd.Core.Models
{
    public class PurchaseInvoiceEntry
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(PurchaseInvoice.PurchaseInvoiceEntry))]
        public virtual PurchaseInvoice Invoice { get; set; }
        public virtual Item Item { get; set; }
    }
}
