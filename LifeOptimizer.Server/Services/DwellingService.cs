using LifeOptimizer.Server.Data;
using LifeOptimizer.Server.Models;
using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Server.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            .FirstOrDefaultAsync(d => d.Id == id);
    }


    public async Task<Dwelling> CreateDwellingAsync(Dwelling dwellingDto)
    {
        // Map DwellingRequestDto to Dwelling
        var dwelling = new Dwelling
        {
            Id = dwellingDto.Id,
            Name = dwellingDto.Name,
            Address = dwellingDto.Address,
        };

        // Add the dwelling
        _context.Dwellings.Add(dwelling);
        await _context.SaveChangesAsync();

        // Reload the dwelling with the address included
        return await _context.Dwellings
            .Include(d => d.Address)
            .FirstOrDefaultAsync(d => d.Id == dwelling.Id);
    }
}

