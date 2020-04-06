using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class EventCreateAndEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GamePlayed { get; set; }
        public string Description { get; set; }
        public int TournamentId { get; set; }
        public decimal Payout { get; set; }
        public decimal EventFee { get; set; }
        public DateTime EventBeginning { get; set; }
    }
    public class EventListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventBeginning { get; set; }
    }
    public class EventDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventBeginning { get; set; }
        public string Description { get; set; }
        public decimal Payout { get; set; }
        public decimal EventFee { get; set; }
    }
}
