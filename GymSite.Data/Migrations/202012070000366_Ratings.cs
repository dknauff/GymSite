namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ratings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GymId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Rank = c.Double(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Gym", t => t.GymId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GymId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Rating", "GymId", "dbo.Gym");
            DropIndex("dbo.Rating", new[] { "GymId" });
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropTable("dbo.Rating");
        }
    }
}
