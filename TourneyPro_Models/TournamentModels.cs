using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name="Date")]
        public DateTime TournamentBeginning { get; set; }
        [Display(Name ="Events")]
        public string ListOfEventNames { get; set; }
    }
}
