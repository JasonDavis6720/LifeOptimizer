using LifeOptimizer.Core.Entities;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.DTOs;

namespace LifeOptimizer.Server.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _RoomRepository;

        public RoomService(IRoomRepository RoomRepository)
        {
            _RoomRepository = RoomRepository;
        }

        public async Task<Room> CreateRoomAsync(RoomDto roomDto)
        {
            // Convert DTO to domain entity
            var room = new Room
            {
                Name = roomDto.Name,
                DwellingId = roomDto.DwellingId
            };

            // Add any additional business logic here (e.g., validation)

            // Pass the domain entity to the repository
            return await _RoomRepository.AddRoomAsync(room);
        }

    }
}
