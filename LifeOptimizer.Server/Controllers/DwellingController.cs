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
            Address = dwelling.Address,
            UserName = dwelling.User?.UserName // Include only the UserName

        };

        return Ok(response);
    }



    // POST: api/dwellings/user/{userId}
    [HttpPost("user/{userId}")]
    public async Task<IActionResult> CreateDwellingForUser(string userId, [FromBody] DwellingRequestDto dwellingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var dwelling = new Dwelling
        {
            Name = dwellingDto.Name,
            Address = dwellingDto.Address,
            UserId = userId // Set UserId from the route parameter
        };

        try
        {
            var createdDwelling = await _dwellingService.CreateDwellingAsync(dwelling);

            // Map to DwellingResponseDto
            var response = new DwellingResponseDto
            {
                Id = createdDwelling.Id,
                Name = createdDwelling.Name,
                Address = createdDwelling.Address,
                UserName = createdDwelling.User?.UserName
            };

            return CreatedAtAction(nameof(GetDwellingById), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }
}

