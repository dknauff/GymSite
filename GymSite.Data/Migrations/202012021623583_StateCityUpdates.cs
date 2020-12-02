namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StateCityUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.City", "StateId", c => c.Int());
            CreateIndex("dbo.City", "StateId");
            AddForeignKey("dbo.City", "StateId", "dbo.State", "StateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropIndex("dbo.City", new[] { "StateId" });
            DropColumn("dbo.City", "StateId");
        }
    }
}
