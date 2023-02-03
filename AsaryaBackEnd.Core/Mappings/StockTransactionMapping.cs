using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AutoMapper;

namespace AsaryaBackEnd.Core.Mappings
{
    public class StockTransactionMapping : Profile
    {
        public StockTransactionMapping()
        {
            CreateMap<StockTransactionDto, StockTransaction>().ReverseMap();
        }
    }
}
