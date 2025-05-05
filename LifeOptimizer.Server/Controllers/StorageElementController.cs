using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageElementController : ControllerBase
    {
        private readonly IStorageElementService _StorageElementService;
        public StorageElementController(IStorageElementService StorageElementService)
        {
            _StorageElementService = StorageElementService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllStorageElementsAsync()
        //{
        //    var response = await _StorageElementService.GetAllStorageElementsAsync();
        //    return Ok(response);
        //}
        ////GET: api/StorageElement/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetStorageElementByIdAsync(int id)
        //{
        //    var response = await _StorageElementService.GetStorageElementByIdAsync(id);
        //    if (response == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(response);
        //}
        //// POST: api/StorageElement
        [HttpPost]
        public async Task<IActionResult> CreateStorageElementAsync([FromBody] StorageElementDto storageElementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _StorageElementService.CreateStorageElementAsync(storageElementDto);
                return Ok(response); // Return the created item directly
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //// Post: api/StorageElement/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateStorageElementAsync(int id, [FromBody] UpdateStorageElementDto updatedStorageElementDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _StorageElementService.UpdateStorageElementAsync(id, updatedStorageElementDto);
        //    if (response == null)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }

        //    return Ok(response); // Return the updated item
        //}

        //// DELETE: api/StorageElement/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStorageElementByIdAsync(int id)
        //{
        //    var success = await _StorageElementService.DeleteStorageElementAsync(id);
        //    if (!success)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }
        //    return NoContent(); // Return 204 No Content on successful deletion
        //}
    }
}
       