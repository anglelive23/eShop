using AutoMapper;
using eShop.Application.Models.Dtos;

namespace eShop.Application.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>()
                .ForAllMembers(o => o.ExplicitExpansion());
        }
    }
}
