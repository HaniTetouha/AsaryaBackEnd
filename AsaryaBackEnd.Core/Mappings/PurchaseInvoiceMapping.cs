using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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