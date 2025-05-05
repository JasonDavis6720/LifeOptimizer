using LifeOptimizer.Core.Entities;


namespace LifeOptimizer.Core.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> AddRoomAsync(Room room);
    }
}
