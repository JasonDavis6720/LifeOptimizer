using LifeOptimizer.Server.Dtos;
using LifeOptimizer.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class DwellingsController : ControllerBase
{
    private readonly IDwellingService _dwellingService;

    public DwellingsController(IDwellingService dwellingService)
    {
        _dwellingService = dwellingService;
    }

    // GET: api/dwellings/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetDwellingsByUserId(string userId)
    {
        var dwellings = await _dwellingService.GetDwellingsByUserIdAsync(userId);
        if (dwellings == null || !dwellings.Any())
        {
            return NotFound();
        }
        return Ok(dwellings);
    }

    // POST: api/dwellings/user/{userId}
    [HttpPost("user/{userId}")]
    public async Task<IActionResult> CreateDwellingForUser(string userId, [FromBody] DwellingRequestDto dwellingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var addressExists = await _dwellingService.AddressExistsAsync(dwellingDto.AddressId);
        if (!addressExists)
        {
            return BadRequest($"Address with ID {dwellingDto.AddressId} does not exist.");
        }


        var dwelling = new Dwelling
        {
            Name = dwellingDto.Name,
            AddressId = dwellingDto.AddressId,
            UserId = userId
        };

        var createdDwelling = await _dwellingService.CreateDwellingAsync(dwelling);

        var response = new DwellingResponseDto
        {
            Id = createdDwelling.Id,
            Name = createdDwelling.Name,
            Address = $"{createdDwelling.Address.Street}, {createdDwelling.Address.City}, {createdDwelling.Address.State}"
        };
        
        return CreatedAtAction(nameof(GetDwellingById), new { id = response.Id }, response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetDwellingById(int id)
    {
        var dwelling = await _dwellingService.GetDwellingByIdAsync(id);
        if (dwelling == null)
        {
            return NotFound();
        }

        var response = new DwellingResponseDto
        {
            Id = dwelling.Id,
            Name = dwelling.Name,
            Address = $"{dwelling.Address.Street}, {dwelling.Address.City}, {dwelling.Address.State}"
        };

        return Ok(response);
    }


    // PUT: api/dwellings/{id}/user/{userId}
    [HttpPut("{id}/user/{userId}")]
    public async Task<IActionResult> UpdateDwellingForUser(int id, string userId, [FromBody] Dwelling dwelling)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        dwelling.UserId = userId; // Ensure the dwelling is associated with the correct user

        var updatedDwelling = await _dwellingService.UpdateDwellingAsync(id, dwelling);
        if (updatedDwelling == null)
        {
            return NotFound();
        }

        return Ok(updatedDwelling);
    }

    // DELETE: api/dwellings/{id}/user/{userId}
    [HttpDelete("{id}/user/{userId}")]
    public async Task<IActionResult> DeleteDwellingForUser(int id, string userId)
    {
        var success = await _dwellingService.DeleteDwellingAsync(id, userId);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
