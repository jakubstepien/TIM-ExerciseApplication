using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationUser : IdentityUser<Guid, GuidIdentityUserLogin, GuidIdentityUserRole, GuidIdentityUserClaim>, IUser, IUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        string IUser<string>.Id
        {
            get
            {
                return Id.ToString();
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Guid> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class GuidIdentityRole : IdentityRole<Guid, GuidIdentityUserRole>
    {
    }

    public class GuidIdentityUserLogin : IdentityUserLogin<Guid>
    {

    }

    public class GuidIdentityUserRole : IdentityUserRole<Guid>
    {
    }

    public class GuidIdentityUserClaim : IdentityUserClaim<Guid>
    {
    }
}
