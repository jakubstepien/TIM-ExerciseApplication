namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainingExcercsieRemoveCompositeKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TrainingExcercises");
            AddColumn("dbo.TrainingExcercises", "Id", c => c.Guid(nullable: false));
            Sql("Update TrainingExcercises Set Id = NEWID()");
            AddPrimaryKey("dbo.TrainingExcercises", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TrainingExcercises");
            DropColumn("dbo.TrainingExcercises", "Id");
            AddPrimaryKey("dbo.TrainingExcercises", new[] { "IdExercise", "IdTraining" });
        }
    }
}
