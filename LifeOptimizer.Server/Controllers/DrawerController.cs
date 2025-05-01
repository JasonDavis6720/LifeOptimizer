using LifeOptimizer.Server.Dtos;
using LifeOptimizer.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawerController : ControllerBase
    {
        private readonly IDrawerService _drawerService;
        public DrawerController(IDrawerService drawerService)
        {
            _drawerService = drawerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrawersAsync()
        {
            var response = await _drawerService.GetAllDrawersAsync();
            return Ok(response);
        }
        //GET: api/Drawer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrawerByIdAsync(int id)
        {
            var response = await _drawerService.GetDrawerByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        // POST: api/Drawer
        [HttpPost]
        public async Task<IActionResult> CreateDrawerAsync([FromBody] Drawer drawer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _drawerService.CreateDrawerAsync(drawer);
                return Ok(response); // Return the created item directly
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Drawer/{drawerId}/AddItem/{itemId}
        [HttpPut("{drawerId}/AddItem/{itemId}")]
        public async Task<IActionResult> AddItemToDrawer(int drawerId, int itemId)
        {
            var result = await _drawerService.AddItemToDrawerAsync(drawerId, itemId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data); // Return the updated InventoryItem
        }
        //// Post: api/Drawer/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateDrawerAsync(int id, [FromBody] UpdateDrawerDto updatedItemDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _drawerService.UpdateDrawerAsync(id, updatedItemDto);
        //    if (response == null)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }

        //    return Ok(response); // Return the updated item
        //}

        // DELETE: api/Drawer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrawerByIdAsync(int id)
        {
            var success = await _drawerService.DeleteDrawerAsync(id);
            if (!success)
            {
                return NotFound(); // Return 404 if the inventory item does not exist
            }
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
