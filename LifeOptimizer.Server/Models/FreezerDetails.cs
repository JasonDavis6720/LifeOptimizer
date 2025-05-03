//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LifeOptimizer.Server.Models
//{
//    public class FreezerDetails
//    {
//        [Key]
//        public int Id { get; set; } // Primary key

//        [Required]
//        public int StorageItemId { get; set; } // Foreign key to the StorageItem

//        [ForeignKey("StorageItemId")]
//        public StorageItem StorageItem { get; set; } // Navigation property to the StorageItem

//        public DateTime? LastDefrostDate { get; set; } // The last time the freezer was defrosted

//        [Required]
//        public TimeSpan DefrostInterval { get; set; } // How often the freezer needs to be defrosted

//        public bool NeedsDefrosting()
//        {
//            if (LastDefrostDate == null)
//                return true;

//            return DateTime.Now - LastDefrostDate >= DefrostInterval;
//        }
//    }
//}
