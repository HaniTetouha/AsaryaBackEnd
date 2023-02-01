using AsaryaBackEnd.Core.Models;
using AsaryaBackEnd.Repo.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaryaBackEnd.Service.Interfaces
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
    }
}
