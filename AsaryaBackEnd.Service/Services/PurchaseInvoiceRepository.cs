using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.Data;
using AsaryaBackEnd.Repo.GenericRepository.Service;
using AsaryaBackEnd.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsaryaBackEnd.Service.Services
{
    public class PurchaseInvoiceRepository : RepositoryBase<PurchaseInvoice>, IPurchaseInvoiceRepository
    {
        public PurchaseInvoiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<PurchaseInvoice?> GetById(int Id, bool trackChanges)
            => await FindByConditionAsync(c => c.Id.Equals(Id), trackChanges).Result.Include(p => p.PurchaseInvoiceEntry).SingleOrDefaultAsync();
    }
}
