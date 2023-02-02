using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.Data;
using AsaryaBackEnd.Repo.GenericRepository.Service;
using AsaryaBackEnd.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsaryaBackEnd.Service.Services
{
    public class SalesInvoiceRepository : RepositoryBase<SalesInvoice>, ISalesInvoiceRepository
    {
        public SalesInvoiceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public new async Task CreateAsync(SalesInvoice salesInvoice)
        {
            await Task.Run(() => RepositoryContext.Set<SalesInvoice>().Add(salesInvoice));
        }
        public async Task<SalesInvoice?> GetById(int Id, bool trackChanges)
            => await FindByConditionAsync(c => c.Id.Equals(Id), trackChanges).Result.Include(p => p.SalesInvoiceEntry).SingleOrDefaultAsync();

    }
}
