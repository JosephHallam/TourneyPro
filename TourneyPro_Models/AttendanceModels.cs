using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class AttendanceCreate
    {
        public int SiteUserId { get; set; }
        public int EventId { get; set; }
        public bool IsPlayer { get; set; }
    }
    public class AttendanceEdit
    {
        public int Id { get; set; }
        public int SiteUserId { get; set; }
        public int EventId { get; set; }
        public bool IsPlayer { get; set; }
    }
    public class AttendanceDetailAndListItem
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string SiteUserName { get; set; }
        public bool IsPlayer { get; set; }
    }
}
