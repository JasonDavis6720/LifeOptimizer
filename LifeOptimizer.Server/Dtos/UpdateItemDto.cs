using System.ComponentModel.DataAnnotations;

namespace LifeOptimizer.Server.Dtos
{
    public class UpdateInventoryItemDto
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int? Quantity { get; set; } // Nullable to allow partial updates
        public string? Unit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsExpired { get; set; }
    }
}