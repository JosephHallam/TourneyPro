namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYTColumnTournament : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "TrailerEmbedLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "TrailerEmbedLink");
        }
    }
}
