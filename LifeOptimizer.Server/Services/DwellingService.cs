using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DwellingService : IDwellingService
{
    private readonly ApplicationDbContext _context;

    public DwellingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dwelling>> GetAllDwellingsAsync()
    {
        return await _context.Dwellings
            .Include(d => d.Address)
            .Include(d => d.Rooms)
            .ToListAsync();
    }

    public async Task<Dwelling> GetDwellingByIdAsync(int id)
    {
        return await _context.Dwellings
            .Include(d => d.Address) // Eagerly load the Address property
            .FirstOrDefaultAsync(d => d.Id == id);
    }



    public async Task<Dwelling> CreateDwellingAsync(Dwelling dwelling)
    {
        _context.Dwellings.Add(dwelling);
        await _context.SaveChangesAsync();

        // Reload the dwelling with the Address property included
        return await _context.Dwellings
            .Include(d => d.Address)
            .FirstOrDefaultAsync(d => d.Id == dwelling.Id);
    }



    public async Task<Dwelling> UpdateDwellingAsync(int id, Dwelling dwelling)
    {
        var existingDwelling = await _context.Dwellings.FindAsync(id);
        if (existingDwelling == null)
        {
            return null;
        }

        existingDwelling.Name = dwelling.Name;
        existingDwelling.AddressId = dwelling.AddressId;
        existingDwelling.UserId = dwelling.UserId;

        _context.Dwellings.Update(existingDwelling);
        await _context.SaveChangesAsync();
        return existingDwelling;
    }

    public async Task<bool> DeleteDwellingAsync(int id, string userId)
    {
        var dwelling = await _context.Dwellings.FirstOrDefaultAsync(d => d.Id == id && d.UserId == userId);
        if (dwelling == null)
        {
            return false;
        }

        _context.Dwellings.Remove(dwelling);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddressExistsAsync(int addressId)
    {
        return await _context.Address.AnyAsync(a => a.Id == addressId);
    }


    public async Task<IEnumerable<Dwelling>> GetDwellingsByUserIdAsync(string userId)
    {
        return await _context.Dwellings
            .Include(d => d.Address)
            .Include(d => d.Rooms)
            .Where(d => d.UserId == userId)
            .ToListAsync();
    }
}
