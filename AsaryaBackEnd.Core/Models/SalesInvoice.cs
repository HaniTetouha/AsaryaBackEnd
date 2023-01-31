namespace AsaryaBackEnd.Core.Models
{
    public class SalesInvoice
    {
        public SalesInvoice() { }

        public int Id { get; set; }
        public int Number { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public string? Remarks { get; set; }
        //[Required(ErrorMessage = "Required field.")]
        public InvoiceStatus Status { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<SalesInvoiceEntry> SalesInvoiceEntry { get; set; }

    }
}
