using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Data
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Beginning of Tournament")]
        public DateTime TournamentBeginning { get; set; }
        [Display(Name="Events")]
        public string ListOfEventNames { get; set; }
        public string TrailerEmbedLink { get; set; }
    }
}
