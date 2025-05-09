namespace LifeOptimizer.Application.Dtos
{
    public class DwellingDto
    {
        public int DwellingId { get; set; }
        public string Name { get; set; } // Name of the dwelling (e.g., "My House")
        public string StreetAddress { get; set; }
        public string? ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; } = "USA";
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();
    }
}
