namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageColumnSiteUserDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteUserDetails", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteUserDetails", "Image");
        }
    }
}
