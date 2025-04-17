using LifeOptimizer.Server.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StorageLocationController : ControllerBase
{
    [HttpPost]
    public IActionResult AddStorageLocation([FromBody] StorageLocationDto storageLocation)
    {
        // Add logic to save the storage location
        return Ok(new { Message = "Storage location added successfully" });
    }
}
