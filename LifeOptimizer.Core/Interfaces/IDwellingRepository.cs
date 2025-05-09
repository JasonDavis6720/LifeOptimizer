using LifeOptimizer.Core.Entities;

namespace LifeOptimizer.Application.Interfaces
{
    public interface IDwellingRepository
    {
        Task<Dwelling> CreateDwellingAsync(Dwelling dwellingDto);
    }
}
