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

    public async Task<DwellingResponseDto> GetDwellingResponseByIdAsync(int id)
    {
        var dwelling = await _context.Dwellings
            .Include(d => d.Address)
            .Include(d => d.User)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dwelling == null)
        {
            return null;
        }

        return new DwellingResponseDto
        {
            Id = dwelling.Id,
            Name = dwelling.Name,
            Address = dwelling.Address,
            UserName = dwelling.User?.UserName
        };
    }

    public async Task<DwellingResponseDto> CreateDwellingForUserAsync(string userId, DwellingRequestDto dwellingDto)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new InvalidOperationException("UserId cannot be null or empty.");
        }

        var dwelling = new Dwelling
        {
            Name = dwellingDto.Name,
            Address = dwellingDto.Address,
            UserId = userId
        };

        _context.Dwellings.Add(dwelling);
        await _context.SaveChangesAsync();

        return new DwellingResponseDto
        {
            Id = dwelling.Id,
            Name = dwelling.Name,
            Address = dwelling.Address,
            UserName = (await _context.Users.FindAsync(userId))?.UserName
        };
    }

    public async Task<bool> DeleteDwellingByIdAsync(int id)
    {
        var dwelling = await _context.Dwellings.FirstOrDefaultAsync(d => d.Id == id);

        if (dwelling == null)
        {
            return false;
        }

        _context.Dwellings.Remove(dwelling);
        await _context.SaveChangesAsync();
        return true;
    }
}
