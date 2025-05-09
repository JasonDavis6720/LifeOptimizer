using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.Dtos;
using AutoMapper;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Infrastructure.Repositories;

namespace LifeOptimizer.Server.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _user;
        
        public RoomService(IRoomRepository roomRepository, AppDbContext context, IMapper mapper, IUserContextService user)
        {
            _context = context;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _user = user;


        }

        public async Task<RoomReturnDto> CreateRoomAsync(CreateRoomDto roomDto)
        {
            var userId = _user.GetCurrentUserId();
            var room = _mapper.Map<Room>(roomDto);
            room.UserId = userId;

            var savedItem = await _roomRepository.AddRoomAsync(room);

            return _mapper.Map<RoomReturnDto>(savedItem);
        }

    }
}
