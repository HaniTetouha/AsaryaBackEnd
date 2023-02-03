using AsaryaBackEnd.Core.Models.Value;

namespace AsaryaBackEnd.Core.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public StockTransactionType Type { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
