namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IRepositoryManager
    {
        IItemRepository Item { get; }
        ISalesInvoiceRepository SalesInvoice { get; }
        IPurchaseInvoiceRepository PurchaseInvoice { get; }
        IUserAuthenticationRepository UserAuthentication { get; }
        IStockTransactionRepository StockTransactionRepository { get; }
        Task SaveAsync();
    }
}
