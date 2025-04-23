using Microsoft.AspNetCore.Mvc;
using LifeOptimizer.Server.Models;
using LifeOptimizer.Server.Services;

namespace LifeOptimizer.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColdStorageController : ControllerBase
    {
        private readonly ColdStorageService _coldStorageService;

        public ColdStorageController(ColdStorageService coldStorageService)
        {
            _coldStorageService = coldStorageService;
        }

        [HttpPost]
        public IActionResult CreateColdStorage([FromBody] ColdStorageDto coldStorageDto)
        {
            try
            {
                var coldStorage = _coldStorageService.CreateColdStorage(
                    coldStorageDto.Name,
                    coldStorageDto.Type,
                    coldStorageDto.IsFrostFree,
                    coldStorageDto.LastDefrosted,
                    coldStorageDto.RoomId,
                    coldStorageDto.DwellingId
                );

                // Save to database (example)
                // _context.ColdStorages.Add(coldStorage);
                // _context.SaveChanges();

                return Ok(coldStorage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class ColdStorageDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? IsFrostFree { get; set; }
        public DateTime? LastDefrosted { get; set; }
        public int RoomId { get; set; }
        public int DwellingId { get; set; }
    }
}
