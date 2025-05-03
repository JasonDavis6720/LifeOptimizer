//using LifeOptimizer.Server.Data;
//using LifeOptimizer.Server.Models;
//using Microsoft.EntityFrameworkCore;

//public class DwellingService : IDwellingService
//{
//    private readonly ApplicationDbContext _context;

//    public DwellingService(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<Dwelling> GetDwellingResponseByIdAsync(int id)
//    {
//        var dwelling = await _context.Dwellings
//            .Include(d => d.User)
//            .FirstOrDefaultAsync(d => d.Id == id);

//        return dwelling;
//    }

//    public async Task<Dwelling> CreateDwellingForUserAsync(string userId, Dwelling dwelling)
//    {
//        if (string.IsNullOrWhiteSpace(userId))
//        {
//            throw new InvalidOperationException("UserId cannot be null or empty.");
//        }

//        dwelling.UserId = userId;
        
//        _context.Dwellings.Add(dwelling);
//        await _context.SaveChangesAsync();

//        return dwelling;
//    }

//    public async Task<bool> DeleteDwellingByIdAsync(int id)
//    {
//        var dwelling = await _context.Dwellings.FirstOrDefaultAsync(d => d.Id == id);

//        if (dwelling == null)
//        {
//            return false;
//        }

//        _context.Dwellings.Remove(dwelling);
//        await _context.SaveChangesAsync();
//        return true;
//    }
//}
