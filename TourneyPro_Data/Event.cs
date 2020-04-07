using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Data
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string GamePlayed { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(Tournament))]
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        [Required]
        public decimal Payout { get; set; }
        [Required]
        public decimal EventFee { get; set; }
        [Required]
        public DateTime EventBeginning { get; set; }
        [Display(Name ="Tournament Name")]
        public string TournamentName { get; set;}
        //[Required]
        //public DateTime EventEnd { get; set; }
        //public TimeSpan TimeSpan { get
        //    {
        //        return EventEnd - EventBeginning
        //    } }
    }
}
