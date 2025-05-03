using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LifeOptimizer.Server.Models
{
    public class User : IdentityUser
    {
        // Full name of the user
        public string FullName { get; set; }
        
        //TEMPORARY: Password property for user creation
        public string Password { get; set; }

    }
}
