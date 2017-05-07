using Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WebApplication.Providers
{
    public class GuidUserStore : UserStore<ApplicationUser, GuidIdentityRole, Guid, GuidIdentityUserLogin, GuidIdentityUserRole, GuidIdentityUserClaim>, IUserStore<ApplicationUser>, IUserStore<ApplicationUser, Guid>, IDisposable
    {
        public GuidUserStore(DbContext context) : base(context)
        {
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            Guid id;
            if(Guid.TryParse(userId, out id))
            {
                return Context.Set<ApplicationUser>().FindAsync(userId);
            }
            return null;
        }
    }
}