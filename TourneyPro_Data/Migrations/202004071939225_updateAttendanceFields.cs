namespace TourneyPro_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAttendanceFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "EventName", c => c.String());
            AddColumn("dbo.Attendances", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "UserName");
            DropColumn("dbo.Attendances", "EventName");
        }
    }
}
