using LifeOptimizer.Application.DTOs;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;
        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllRoomsAsync()
        //{
        //    var response = await _RoomService.GetAllRoomsAsync();
        //    return Ok(response);
        //}
        ////GET: api/Room/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRoomByIdAsync(int id)
        //{
        //    var response = await _RoomService.GetRoomByIdAsync(id);
        //    if (response == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(response);
        //}
        //// POST: api/Room
        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync([FromBody] RoomDto storageElementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = await _RoomService.CreateRoomAsync(storageElementDto);
                return Ok(response); // Return the created item directly
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //// Post: api/Room/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRoomAsync(int id, [FromBody] UpdateRoomDto updatedRoomDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _RoomService.UpdateRoomAsync(id, updatedRoomDto);
        //    if (response == null)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }

        //    return Ok(response); // Return the updated item
        //}

        //// DELETE: api/Room/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRoomByIdAsync(int id)
        //{
        //    var success = await _RoomService.DeleteRoomAsync(id);
        //    if (!success)
        //    {
        //        return NotFound(); // Return 404 if the inventory item does not exist
        //    }
        //    return NoContent(); // Return 204 No Content on successful deletion
        //}
    }
}
       