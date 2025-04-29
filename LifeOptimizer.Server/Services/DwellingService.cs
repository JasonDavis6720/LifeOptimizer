using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;

public class DwellingService : IDwellingService
{
    private readonly ApplicationDbContext _context;

    public DwellingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Dwelling> GetDwellingByIdAsync(int id)
        {
            return await _context.Dwellings
                .Include(d => d.Address) // Eagerly load the Address property
                .Include(d => d.User)    // Eagerly load the User property
                .FirstOrDefaultAsync(d => d.Id == id);
        }



    public async Task<Dwelling> CreateDwellingAsync(Dwelling dwelling)
    {
        if (string.IsNullOrWhiteSpace(dwelling.UserId))
        {
            throw new InvalidOperationException("UserId cannot be null or empty.");
        }

        _context.Dwellings.Add(dwelling);
        await _context.SaveChangesAsync();

        return await _context.Dwellings
            .Include(d => d.Address)
            .Include(d => d.User) // Eagerly load the User property
            .FirstOrDefaultAsync(d => d.Id == dwelling.Id);
    }

}

