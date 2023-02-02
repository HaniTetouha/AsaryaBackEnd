using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AutoMapper;

namespace AsaryaBackEnd.Core.Mappings
{
    public class PurchaseInvoiceMapping : Profile
    {
        public PurchaseInvoiceMapping()
        {
            CreateMap<PurchaseInvoiceDto, PurchaseInvoice>().ReverseMap();
            CreateMap<PurchaseInvoiceEntryDto, PurchaseInvoiceEntry>().ReverseMap();
        }
    }
}