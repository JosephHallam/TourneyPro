namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEventFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TournamentName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "TournamentName");
        }
    }
}
