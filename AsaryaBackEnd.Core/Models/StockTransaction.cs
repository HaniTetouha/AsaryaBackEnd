using AsaryaBackEnd.Core.Models.Value;

namespace AsaryaBackEnd.Core.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public StockTransactionType Type { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Item Item { get; set; }

    }

}
