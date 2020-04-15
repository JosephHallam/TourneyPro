using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class AttendanceCreate
    {
        [Display(Name ="SiteUser Id")]
        public int SiteUserId { get; set; }
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Display(Name = "Attending As Player?")]
        public bool IsPlayer { get; set; }
    }
    public class AttendanceEdit
    {
        public int Id { get; set; }
        [Display(Name = "SiteUser Id")]
        public int SiteUserId { get; set; }
        [Display(Name = "Event Id")]
        public int EventId { get; set; }
        [Display(Name = "Attending As Player?")]
        public bool IsPlayer { get; set; }
    }
    public class AttendanceDetailAndListItem
    {
        public int Id { get; set; }
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Display(Name = "SiteUser Name")]
        public string SiteUserName { get; set; }
        [Display(Name = "Attending As Player?")]
        public bool IsPlayer { get; set; }
    }
}
