using LifeOptimizer.Server.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;
        public InventoryItemController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInventoryItemsAsync()
        {
            var response = await _inventoryItemService.GetAllInventoryItemsAsync();
            return Ok(response);
        }
        //GET: api/InventoryItem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItemByIdAsync(int id)
        {
            var response = await _inventoryItemService.GetInventoryItemByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        // POST: api/InventoryItem
        [HttpPost]
        public async Task<IActionResult> CreateInventoryItemAsync([FromBody] InventoryItem inventoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _inventoryItemService.CreateInventoryItemAsync(inventoryItem);
                return Ok(response); // Return the created item directly
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Post: api/InventoryItem/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryItemAsync(int id, [FromBody] JsonPatchDocument<InventoryItem> patchDoc)
        {
            
        }



        // DELETE: api/InventoryItem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItemByIdAsync(int id)
        {
            var success = await _inventoryItemService.DeleteInventoryItemAsync(id);
            if (!success)
            {
                return NotFound(); // Return 404 if the inventory item does not exist
            }
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
       