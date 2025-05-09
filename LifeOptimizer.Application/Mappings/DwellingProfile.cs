using AutoMapper;
using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Mappings
{
    public class DwellingProfile : Profile
    {
        public DwellingProfile()
        {
            CreateMap<CreateDwellingDto, Dwelling>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Dwelling, DwellingReturnDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name != null ? src.Name : null));
        }
    }
}
