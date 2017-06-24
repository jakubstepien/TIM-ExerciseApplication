namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDescriptionLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercise", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercise", "Description", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
