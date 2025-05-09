using AutoMapper;
using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;

namespace LifeOptimizer.Server.Services
{
    public class DwellingService : IDwellingService
    {
        private readonly AppDbContext _context;
        private readonly IDwellingRepository _dwellingRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _user;

        public DwellingService(AppDbContext context, IDwellingRepository dwellingRepository, IMapper mapper, IUserContextService user)
        {
            _context = context;
            _dwellingRepository = dwellingRepository;
            _mapper = mapper;
            _user = user;

        }

        public async Task<DwellingReturnDto> CreateDwellingAsync(CreateDwellingDto dwellingDto)
        {
            // Convert DTO to domain entity
            var userId = _user.GetCurrentUserId();
            var dwelling = _mapper.Map<Dwelling>(dwellingDto);
            dwelling.UserId = userId;

            var savedDwelling = await _dwellingRepository.CreateDwellingAsync(dwelling);

            return _mapper.Map<DwellingReturnDto>(savedDwelling);
        }

    }
}
