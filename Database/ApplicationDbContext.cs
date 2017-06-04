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
            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingExcercise> TrainingExcercise { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
        public DbSet<UserExcercise> UserExcercise { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<GuidIdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<GuidIdentityUserLogin>().ToTable("Login");
            modelBuilder.Entity<GuidIdentityUserClaim>().ToTable("Claim");
            modelBuilder.Entity<GuidIdentityRole>().ToTable("Role");
        }
    }
}
