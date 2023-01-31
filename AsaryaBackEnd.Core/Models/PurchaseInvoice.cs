namespace AsaryaBackEnd.Core.Models
{
    public class PurchaseInvoice
    {
        PurchaseInvoice() { }

        public int Id { get; set; }
        public int Number { get; set; }
        public int SupplierId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public string? Remarks { get; set; }
        public InvoiceStatus Status { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseInvoiceEntry> PurchaseInvoiceEntry { get; set; }
    }
}
