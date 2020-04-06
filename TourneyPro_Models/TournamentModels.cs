using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class TournamentCreate
    {
        public string Name { get; set; }
        public DateTime TournamentBeginning { get; set; }
    }
    public class TournamentEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentBeginning { get; set; }
    }
    public class TournamentDetailAndListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentBeginning { get; set; }
        public string ListOfEventNames { get; set; }
    }
}
