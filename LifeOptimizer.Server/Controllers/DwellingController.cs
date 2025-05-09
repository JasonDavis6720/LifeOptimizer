using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DwellingsController : ControllerBase
{
    private readonly IDwellingService _dwellingService;

    public DwellingsController(IDwellingService dwellingService)
    {
        _dwellingService = dwellingService;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetDwellingByIdAsync(int id)
    //{
    //    var response = await _dwellingService.GetDwellingResponseByIdAsync(id);
    //    if (response == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(response);
    //}

    [HttpPost]
    public async Task<ActionResult<CreateDwellingDto>> CreateDwellingAsync([FromBody] CreateDwellingDto dwellingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var dwelling = await _dwellingService.CreateDwellingAsync(dwellingDto);
            return Ok($"Dwelling: {dwellingDto.Name} created successfully");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteDwellingByIdAsync(int id)
    //    {
    //        var success = await _dwellingService.DeleteDwellingByIdAsync(id);
    //        if (!success)
    //        {
    //            return NotFound(); // Return 404 if the dwelling does not exist
    //        }

    //        return NoContent(); // Return 204 No Content on successful deletion
    //    }


}

