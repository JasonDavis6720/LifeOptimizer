using Microsoft.AspNetCore.Identity;

namespace LifeOptimizer.Server.Models
{
    public class User
    {
        public string FullName { get; set; } // e.g., "John Doe"
        public string Email { get; set; }
        public List<Dwelling> Dwellings { get; set; } // List of dwellings associated with the user

    }
}
