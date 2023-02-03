using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.Data;
using AsaryaBackEnd.Repo.GenericRepository.Service;
using AsaryaBackEnd.Service.Interfaces;

namespace AsaryaBackEnd.Service.Services
{
    public class StockTransactionRepository : RepositoryBase<StockTransaction>, IStockTransactionRepository
    {
        public StockTransactionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
