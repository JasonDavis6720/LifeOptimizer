using System.ComponentModel.DataAnnotations;

namespace LifeOptimizer.Domain
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; } // Changed from field to property
        public string Name { get; set; }
        public string Category { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public bool? IsExpired { get; set; }
        public int? DrawerId { get; set; }
        public int? ShelfId { get; set; }
    }

}
