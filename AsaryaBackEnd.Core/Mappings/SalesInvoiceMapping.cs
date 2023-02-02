using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AutoMapper;

namespace AsaryaBackEnd.Core.Mappings
{
    public class SalesInvoiceMapping : Profile
    {
        public SalesInvoiceMapping()
        {
            CreateMap<SalesInvoiceDto, SalesInvoice>().ReverseMap();
            CreateMap<SalesInvoiceEntryDto, SalesInvoiceEntry>().ReverseMap();
        }
    }
}
