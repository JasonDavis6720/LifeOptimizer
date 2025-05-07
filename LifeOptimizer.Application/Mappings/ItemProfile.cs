using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Core.Entities;
using AutoMapper;


namespace LifeOptimizer.Application.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemReturnDto>()
                .ForMember(dest => dest.StorageElementName,
                    opt => opt.MapFrom(src => src.StorageElement != null ? src.StorageElement.Name : null));

            CreateMap<CreateItemDto, Item>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // We'll set this manually}

        }
    }
}