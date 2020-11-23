namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Stars = c.Int(nullable: false),
                        Title = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Review");
        }
    }
}
