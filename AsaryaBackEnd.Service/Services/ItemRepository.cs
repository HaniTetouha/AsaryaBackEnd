using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.Data;
using AsaryaBackEnd.Repo.GenericRepository.Service;
using AsaryaBackEnd.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsaryaBackEnd.Service.Services
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Item?> GetById(int Id, bool trackChanges)
            => await FindByConditionAsync(c => c.Id.Equals(Id), trackChanges).Result.SingleOrDefaultAsync();
    }
}
