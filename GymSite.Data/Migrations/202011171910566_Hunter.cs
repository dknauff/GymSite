namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hunter : DbMigration
    {
        public override void Up()
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
            
            DropTable("dbo.Account");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            DropTable("dbo.Hunter");
        }
    }
}
