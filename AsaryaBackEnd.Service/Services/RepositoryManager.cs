using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.Data;
using AsaryaBackEnd.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AsaryaBackEnd.Service.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IMapper _mapper;
        private IConfiguration _configuration;
        private IUserAuthenticationRepository _userAuthenticationRepository;
        private IPurchaseInvoiceRepository _purchaseInvoiceRepository;
        private ISalesInvoiceRepository _salesInvoiceRepository;
        private IItemRepository _itemRepository;
        private IStockTransactionRepository _stockTransactionRepository;
        private UserManager<User> _userManager;

        public RepositoryManager(RepositoryContext repositoryContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _repositoryContext = repositoryContext;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IUserAuthenticationRepository UserAuthentication
        {
            get
            {
                return _userAuthenticationRepository ??= new UserAuthenticationRepository(_userManager, _configuration, _mapper);
            }
        }

        public IItemRepository Item
        {
            get
            {
                return _itemRepository ??= new ItemRepository(_repositoryContext);
            }
        }

        public ISalesInvoiceRepository SalesInvoice
        {
            get
            {
                return _salesInvoiceRepository ??= new SalesInvoiceRepository(_repositoryContext);
            }
        }

        public IPurchaseInvoiceRepository PurchaseInvoice
        {
            get
            {
                return _purchaseInvoiceRepository ??= new PurchaseInvoiceRepository(_repositoryContext);
            }
        }

        public IStockTransactionRepository StockTransactionRepository
        {
            get
            {
                return _stockTransactionRepository ??= new StockTransactionRepository(_repositoryContext);
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }

}
