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
    public async Task<IActionResult> GetDwellingByIdAsync(int id)
    {
        var response = await _dwellingService.GetDwellingResponseByIdAsync(id);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost("user/{userId}")]
    public async Task<IActionResult> CreateDwellingForUserAsync(string userId, [FromBody] Dwelling dwelling)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var response = await _dwellingService.CreateDwellingForUserAsync(userId, dwelling);
            return CreatedAtAction(nameof(GetDwellingByIdAsync), new { id = response.Id }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDwellingByIdAsync(int id)
    {
        var success = await _dwellingService.DeleteDwellingByIdAsync(id);
        if (!success)
        {
            return NotFound(); // Return 404 if the dwelling does not exist
        }

        return NoContent(); // Return 204 No Content on successful deletion
    }


}

