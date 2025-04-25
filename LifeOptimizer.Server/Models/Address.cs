using System.ComponentModel.DataAnnotations;

public class Address
{
    [Key]
    public int Id { get; set; } // Primary key

    [Required]
    [MaxLength(100)]
    public string Street { get; set; } // e.g., "123 Main St"

    [Required]
    [MaxLength(50)]
    public string City { get; set; } // e.g., "Springfield"

    [Required]
    [MaxLength(50)]
    public string State { get; set; } // e.g., "IL"

    [Required]
    [MaxLength(10)]
    public string ZipCode { get; set; } // e.g., "62704"

    [MaxLength(50)]
    public string Country { get; set; } = "USA"; // Default to "USA"
}
