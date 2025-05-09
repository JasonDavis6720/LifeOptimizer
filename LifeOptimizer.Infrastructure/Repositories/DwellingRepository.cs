using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Entities;
using LifeOptimizer.Infrastructure.Data;

namespace LifeOptimizer.Infrastructure.Repositories
{
    public class DwellingRepository : IDwellingRepository
    {
        private readonly AppDbContext _dbContext;

        public DwellingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Dwelling> CreateDwellingAsync(Dwelling dwellingDto)
        {
            _dbContext.Dwellings.Add(dwellingDto);
            await _dbContext.SaveChangesAsync();
            return dwellingDto;
        }
    }
}
