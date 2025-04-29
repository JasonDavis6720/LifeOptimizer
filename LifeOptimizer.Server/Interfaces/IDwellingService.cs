using LifeOptimizer.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDwellingService
{
    Task<IEnumerable<Dwelling>> GetAllDwellingsAsync();
    Task<Dwelling> GetDwellingByIdAsync(int id);
    Task<Dwelling> CreateDwellingAsync(Dwelling dwelling);
    Task<Dwelling> UpdateDwellingAsync(int id, Dwelling dwelling);
    Task<bool> DeleteDwellingAsync(int id, string userId);
    Task<bool> AddressExistsAsync(int addressId);
    Task<IEnumerable<Dwelling>> GetDwellingsByUserIdAsync(string userId);

}
