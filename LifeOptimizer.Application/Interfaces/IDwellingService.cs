using LifeOptimizer.Application.Dtos;


namespace LifeOptimizer.Application.Interfaces
{
    public interface IDwellingService
    {
        Task<DwellingReturnDto> CreateDwellingAsync(CreateDwellingDto dwelling);
    }
}
