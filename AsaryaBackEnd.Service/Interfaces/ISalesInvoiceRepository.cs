using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.GenericRepository.Interface;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface ISalesInvoiceRepository : IRepositoryBase<SalesInvoice>
    {
        Task<SalesInvoice?> GetById(int Id, bool trackChanges);
    }
}
