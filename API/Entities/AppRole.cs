using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    // Many to many: each AppUser can have multiple roles and each AppRole can have multiple users
    public class AppRole: IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles{ get; set; }
    }
}