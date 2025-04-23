using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LifeOptimizer.Server.Models
{
    public class User: IdentityUser
    {
        public string FullName { get; set; } // Additional property for the user's full name

        public List<Dwelling> Dwellings { get; set; } // Navigation property for the user's dwellings
    }
}