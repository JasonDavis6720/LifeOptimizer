using LifeOptimizer.Server.Interfaces;
using LifeOptimizer.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpPost("add")]
    public IActionResult AddInventoryItem([FromBody] InventoryItem item)
    {
        // Example: Add the item to a specific storage (e.g., freezer)
        var storage = new BaseStorage
        {
            Id = 1, // Example storage ID
            Name = "Freezer",
            InventoryItems = new List<InventoryItem>()
        };

        _inventoryService.AddInventoryItem(storage, item);
        return Ok(new { message = "Item added successfully!" });
    }
}
