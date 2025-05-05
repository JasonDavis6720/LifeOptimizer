using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LifeOptimizer.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }
    }
}