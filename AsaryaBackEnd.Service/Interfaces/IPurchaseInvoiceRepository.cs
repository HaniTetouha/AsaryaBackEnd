using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.GenericRepository.Interface;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IPurchaseInvoiceRepository : IRepositoryBase<PurchaseInvoice>
    {
        Task<PurchaseInvoice?> GetById(int Id, bool trackChanges);

    }
}
