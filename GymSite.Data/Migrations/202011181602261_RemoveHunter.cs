namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHunter : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Hunter");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Hunter",
                c => new
                    {
                        HunterId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.HunterId);
            
        }
    }
}
