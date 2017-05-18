using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, GuidIdentityRole, Guid, GuidIdentityUserLogin, GuidIdentityUserRole, GuidIdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        //public DbSet<Exercise> Exercise { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
