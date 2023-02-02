using AsaryaBackEnd.Core.DTOs;
using AsaryaBackEnd.Core.Models;
using AutoMapper;

namespace AsaryaBackEnd.Core.Mappings
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<ItemDto, Item>().ReverseMap();
        }
    }
}
