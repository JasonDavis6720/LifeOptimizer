using LifeOptimizer.Server.Models;
using LifeOptimizer.Server.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public interface IDwellingService
{
    Task<Dwelling> GetDwellingByIdAsync(int id);

    Task<Dwelling> CreateDwellingAsync(Dwelling dwelling);
}

