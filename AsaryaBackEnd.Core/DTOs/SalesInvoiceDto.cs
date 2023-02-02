namespace AsaryaBackEnd.Core.DTOs
{
    public class SalesInvoiceDto
    {
        public int Id { get; init; }
        public int Number { get; init; }
        public int CustomerId { get; init; }
        public decimal? TotalAmount { get; init; }
        public decimal? Discount { get; init; }
        public string? Remarks { get; init; }
        public InvoiceStatus Status { get; init; }
        public DateTime EntryDate { get; init; }
        public ICollection<SalesInvoiceEntryDto> SalesInvoiceEntry { get; init; }
    }
}
