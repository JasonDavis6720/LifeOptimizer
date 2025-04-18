﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOptimizer.Server.Models
{
    public class Dwelling
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Name of the dwelling

        [ForeignKey("UserId")]
        public string UserId { get; set; } // Foreign key to the User

        public User User { get; set; } // Navigation property to the User
    }
}
