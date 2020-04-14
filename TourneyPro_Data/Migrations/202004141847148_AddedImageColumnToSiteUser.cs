namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageColumnToSiteUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteUsers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteUsers", "Image");
        }
    }
}
