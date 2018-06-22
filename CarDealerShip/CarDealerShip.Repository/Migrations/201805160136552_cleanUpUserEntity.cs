namespace CarDealerShip.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanUpUserEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String());
        }
    }
}
