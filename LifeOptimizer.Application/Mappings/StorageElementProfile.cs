using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Core.Entities;
using AutoMapper;


namespace LifeOptimizer.Application.Mappings
{
    public class StorageElementProfile : Profile
    {
        public StorageElementProfile()
        {
            CreateMap<StorageElement, StorageElementDto>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomId : (int?)null))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : null))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
