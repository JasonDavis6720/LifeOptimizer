using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Core.Entities;
using AutoMapper;


namespace LifeOptimizer.Application.Mappings
{
    public class StorageElementProfile : Profile
    {
        public StorageElementProfile()
        {
            // Map from Create DTO to Entity
            CreateMap<CreateStorageElementDto, StorageElement>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // Map from Entity to Return DTO
            CreateMap<StorageElement, StorageElementReturnDto>()
                .ForMember(dest => dest.RoomName,
                    opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : null));
        }
    }
}
