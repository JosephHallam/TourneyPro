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
        public DateTime TournamentBeginning { get; set; }
        public ICollection<Event> Events { get; set; }
        public string ListOfEventNames { get
            {
                return string.Join(", ", Events);
            } }
    }
}
