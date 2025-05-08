using LifeOptimizer.Application.Dtos;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IRoomService
    {
        Task<RoomReturnDto> CreateRoomAsync(CreateRoomDto roomDto);
    }
}
