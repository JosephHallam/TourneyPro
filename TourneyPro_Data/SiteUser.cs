using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Data
{
    public class SiteUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public bool IsVerified { get; set; }
   //     public ICollection<Attendance> Attendance { get; set; }
    }
}
