namespace GymSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGym : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gym", "MonthlyCost", c => c.String());
            AddColumn("dbo.Gym", "Hours", c => c.String());
            AddColumn("dbo.Gym", "Equiptment", c => c.String());
            AddColumn("dbo.Gym", "LockerRoom", c => c.String());
            AddColumn("dbo.Gym", "Classes", c => c.String());
            AddColumn("dbo.Gym", "PersonalTraining", c => c.String());
            AddColumn("dbo.Gym", "AdditionalInfo", c => c.String());
            DropColumn("dbo.Gym", "MembershipPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gym", "MembershipPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Gym", "AdditionalInfo");
            DropColumn("dbo.Gym", "PersonalTraining");
            DropColumn("dbo.Gym", "Classes");
            DropColumn("dbo.Gym", "LockerRoom");
            DropColumn("dbo.Gym", "Equiptment");
            DropColumn("dbo.Gym", "Hours");
            DropColumn("dbo.Gym", "MonthlyCost");
        }
    }
}
