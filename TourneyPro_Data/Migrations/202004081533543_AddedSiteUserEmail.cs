namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSiteUserEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteUsers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteUsers", "Email");
        }
    }
}
