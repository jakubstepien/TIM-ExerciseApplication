namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercise", "ImageName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercise", "ImageName");
        }
    }
}
