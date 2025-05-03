namespace LifeOptimizer.Core.Entities
{

    public class Dwelling
    {
        public int DwellingId { get; set; }
        public string Name { get; set; } // Name of the dwelling (e.g., "My House")
        public string StreetAddress { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; } = "USA";
        public string UserId { get; set; } // Foreign key to the User
    }
}