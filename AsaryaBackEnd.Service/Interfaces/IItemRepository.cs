using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.GenericRepository.Interface;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Task<Item?> GetById(int Id, bool trackChanges);
    }
}
