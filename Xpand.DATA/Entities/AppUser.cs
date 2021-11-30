using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Xpand.DATA.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
        public string RobotsCrew { get; set; }
    }
}