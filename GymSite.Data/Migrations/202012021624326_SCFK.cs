namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SCFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropIndex("dbo.City", new[] { "StateId" });
            AlterColumn("dbo.City", "StateId", c => c.Int(nullable: true));
            CreateIndex("dbo.City", "StateId");
            AddForeignKey("dbo.City", "StateId", "dbo.State", "StateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropIndex("dbo.City", new[] { "StateId" });
            AlterColumn("dbo.City", "StateId", c => c.Int());
            CreateIndex("dbo.City", "StateId");
            AddForeignKey("dbo.City", "StateId", "dbo.State", "StateId");
        }
    }
}
