using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class EventCreateAndEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Game Played")]
        public string GamePlayed { get; set; }
        public string Description { get; set; }
        [Display(Name = "Tournament Id")]
        public int TournamentId { get; set; }
        public decimal Payout { get; set; }
        [Display(Name = "Fee")]
        public decimal EventFee { get; set; }
        [Display(Name = "Beginning of Event")]
        public DateTime EventBeginning { get; set; }
    }
    public class EventListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Beginning of Event")]
        public DateTime EventBeginning { get; set; }
    }
    public class EventDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Beginning of Event")]
        public DateTime EventBeginning { get; set; }
        public string Description { get; set; }
        public decimal Payout { get; set; }
        [Display(Name = "Fee")]
        public decimal EventFee { get; set; }
    }
}
