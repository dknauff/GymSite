namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Equipment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gym", "Equipment", c => c.String());
            DropColumn("dbo.Gym", "Equiptment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gym", "Equiptment", c => c.String());
            DropColumn("dbo.Gym", "Equipment");
        }
    }
}
