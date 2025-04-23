using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class ColdStorage : BaseStorage
    {
        // Type of cold storage (e.g., Refrigerator, Freezer)
        [Required]
        [MaxLength(50)] // Limit the length to 50 characters
        public string Type { get; set; }

        // Indicates whether the storage is frost-free
        public bool? IsFrostFree { get; set; }

        // Last defrost date
        public DateTime? LastDefrosted { get; set; }

        // Calculated property for the next defrost date
        [NotMapped] // Exclude from the database since it's calculated
        public DateTime? NextDefrosted => LastDefrosted?.AddMonths(12);
    }
}
