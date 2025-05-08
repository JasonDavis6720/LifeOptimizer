using AutoMapper;
using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<CreateRoomDto, Room>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Room, RoomDto>(); // Simple map

            CreateMap<Room, RoomReturnDto>()
                            .ForMember(dest => dest.DwellingName,
                                opt => opt.MapFrom(src => src.Dwelling != null ? src.Dwelling.Name : null));
        }
    }
}
