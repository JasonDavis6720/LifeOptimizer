using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IRoomService
    {
        Task<Room> CreateRoomAsync(RoomDto roomDto);
    }
}
