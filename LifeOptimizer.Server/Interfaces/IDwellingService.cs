using LifeOptimizer.Server.Models;

public interface IDwellingService
{
    //TODO: Remove
    Task<Dwelling> GetDwellingByIdAsync(int id);

    Task<Dwelling> CreateDwellingAsync(Dwelling dwelling);

    //TODO: Methods To Add
    //DeleteDwellingAsync();
    //UpdateDwellingAsync();

}

