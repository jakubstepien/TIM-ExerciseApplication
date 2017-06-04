namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercise",
                c => new
                    {
                        IdExercise = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 256),
                        Image = c.Binary(),
                        CaloriesPerHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExercise);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        IdStatistic = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ExerciseName = c.String(nullable: false, maxLength: 256),
                        Callories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdUser = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdStatistic)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.Date)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserExcercise",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        IdExercise = c.Guid(nullable: false),
                        IsFavourite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.IdExercise })
                .ForeignKey("dbo.Exercise", t => t.IdExercise, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.IdExercise);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Training",
                c => new
                    {
                        IdTraining = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        IdUser = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdTraining)
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.TrainingExcercises",
                c => new
                    {
                        IdExercise = c.Guid(nullable: false),
                        IdTraining = c.Guid(nullable: false),
                        Series = c.Int(nullable: false),
                        Interval = c.Int(nullable: false),
                        TimeSpan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdExercise, t.IdTraining })
                .ForeignKey("dbo.Exercise", t => t.IdExercise, cascadeDelete: true)
                .ForeignKey("dbo.Training", t => t.IdTraining, cascadeDelete: true)
                .Index(t => t.IdExercise)
                .Index(t => t.IdTraining);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "IdUser", "dbo.User");
            DropForeignKey("dbo.Training", "IdUser", "dbo.User");
            DropForeignKey("dbo.TrainingExcercises", "IdTraining", "dbo.Training");
            DropForeignKey("dbo.TrainingExcercises", "IdExercise", "dbo.Exercise");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Login", "UserId", "dbo.User");
            DropForeignKey("dbo.UserExcercise", "UserId", "dbo.User");
            DropForeignKey("dbo.UserExcercise", "IdExercise", "dbo.Exercise");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.TrainingExcercises", new[] { "IdTraining" });
            DropIndex("dbo.TrainingExcercises", new[] { "IdExercise" });
            DropIndex("dbo.Training", new[] { "IdUser" });
            DropIndex("dbo.Login", new[] { "UserId" });
            DropIndex("dbo.UserExcercise", new[] { "IdExercise" });
            DropIndex("dbo.UserExcercise", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Statistics", new[] { "IdUser" });
            DropIndex("dbo.Statistics", new[] { "Date" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropTable("dbo.TrainingExcercises");
            DropTable("dbo.Training");
            DropTable("dbo.Login");
            DropTable("dbo.UserExcercise");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.Statistics");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Exercise");
        }
    }
}
