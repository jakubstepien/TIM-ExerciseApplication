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
    public class GuidUserStore : UserStore<ApplicationUser, GuidIdentityRole, Guid, GuidIdentityUserLogin, GuidIdentityUserRole, GuidIdentityUserClaim>,
        IUserStore<ApplicationUser, Guid>, 
        IUserRoleStore<ApplicationUser,Guid>,
        IUserLockoutStore<ApplicationUser, Guid>,
        IUserPasswordStore<ApplicationUser, Guid>,
        IUserTwoFactorStore<ApplicationUser,Guid>,
        IDisposable
    {
        public GuidUserStore(DbContext context) : base(context)
        {
        }

     
    }
}