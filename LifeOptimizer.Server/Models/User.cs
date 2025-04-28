using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LifeOptimizer.Server.Models
{
    public class User : IdentityUser
    {
        // Full name of the user
        public string FullName { get; set; }

        // List of dwellings associated with the user
        public ICollection<Dwelling> Dwellings { get; set; } = new List<Dwelling>();
    }
}
