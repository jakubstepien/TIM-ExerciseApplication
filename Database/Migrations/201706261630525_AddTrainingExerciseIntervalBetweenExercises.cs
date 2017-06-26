namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainingExerciseIntervalBetweenExercises : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingExcercises", "IntervalBeforeNextExercise", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingExcercises", "IntervalBeforeNextExercise");
        }
    }
}
