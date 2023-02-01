using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IRepositoryManager
    {
        IItemRepository Item { get; }
        ISalesInvoiceRepository SalesInvoice { get; }
        IPurchaseInvoiceRepository PurchaseInvoice { get; }
        IUserAuthenticationRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}
