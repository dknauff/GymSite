namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewGymFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "GymId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "GymId");
            AddForeignKey("dbo.Review", "GymId", "dbo.Gym", "GymId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "GymId", "dbo.Gym");
            DropIndex("dbo.Review", new[] { "GymId" });
            DropColumn("dbo.Review", "GymId");
        }
    }
}
