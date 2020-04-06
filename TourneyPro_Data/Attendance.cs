using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Data
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(SiteUser))]
        public int SiteUserId { get; set; }
        public virtual SiteUser SiteUser { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public bool isPlayer { get; set; }
    }
}
