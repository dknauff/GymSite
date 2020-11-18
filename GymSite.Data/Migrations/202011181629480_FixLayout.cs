namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLayout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gym", "Phone", c => c.String());
            DropColumn("dbo.Gym", "HasMultipleLocations");
            DropColumn("dbo.Gym", "HasClasses");
            DropColumn("dbo.Gym", "HasPersonalTraining");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gym", "HasPersonalTraining", c => c.Boolean(nullable: false));
            AddColumn("dbo.Gym", "HasClasses", c => c.Boolean(nullable: false));
            AddColumn("dbo.Gym", "HasMultipleLocations", c => c.Boolean(nullable: false));
            DropColumn("dbo.Gym", "Phone");
        }
    }
}
