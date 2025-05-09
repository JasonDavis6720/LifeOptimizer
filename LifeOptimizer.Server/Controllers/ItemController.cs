using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Application.Dtos;
using LifeOptimizer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _ItemService;
        public ItemController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }
        //[HttpGet]
        //public async Task<ActionResult<List<ItemReturnDto>>> GetAllItemsAsync()
        //{
        //    var items = await _ItemService.GetAllItemsAsync();
        //    return Ok(items);
        //}
        //GET: api/InventoryItem/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var item = await _ItemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        //// POST: api/InventoryItem
        [HttpPost]
        public async Task<IActionResult> CreateItemAsync([FromBody] CreateItemDto Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _ItemService.CreateItemAsync(Item);
                //return Ok(response); // Return the created item directly
                return Ok($"Item: {response.Name} created successfully");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemReturnDto>>> GetItems()
        {
            var items = await _ItemService.GetAllItemsAsync();
            return Ok(items);
        }
        //// Post: api/InventoryItem/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateInventoryItemAsync(int id, [FromBody] UpdateInventoryItemDto updatedItemDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _ItemService.UpdateInventoryItemAsync(id, updatedItemDto);
        //    if (response == null)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }

        //    return Ok(response); // Return the updated item
        //}

        //// DELETE: api/InventoryItem/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteInventoryItemByIdAsync(int id)
        //{
        //    var success = await _ItemService.DeleteInventoryItemAsync(id);
        //    if (!success)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }
        //    return NoContent(); // Return 204 No Content on successful deletion
        //}
    }
}
