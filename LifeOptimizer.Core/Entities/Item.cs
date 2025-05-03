using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LifeOptimizer.Core.Entities
{
    public class Item
    {

        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public bool? IsExpired { get; set; }

        public int? StorageLocationId { get; set; }
        public StorageLocation StorageLocation { get; set; }
    }

}