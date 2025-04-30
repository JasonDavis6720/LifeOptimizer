using LifeOptimizer.Server.Models;
public class DwellingResponseDto
{
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string UserName { get; set; } // Include only the UserName

}

