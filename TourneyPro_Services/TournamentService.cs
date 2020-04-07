using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourneyPro.Models;
using TourneyPro_Data;

namespace TourneyPro_Services
{
    public class TournamentService
    {
        public Guid _userId;
        public TournamentService(Guid id)
        {
            _userId = id;
        }
        public bool CreateTournament(TourneyPro_Models.TournamentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tournament = new Tournament()
                {
                    Name = model.Name,
                    TournamentBeginning = model.TournamentBeginning,
                };
                ctx.Tournaments.Add(tournament);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TourneyPro_Models.TournamentDetailAndListItem> GetAllTournaments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Tournaments.Where(e => e.Id != 0).Select(e => new TourneyPro_Models.TournamentDetailAndListItem
                {
                    Id = e.Id,
                   // ListOfEventNames = e.ListOfEventNames,
                    Name = e.Name,
                    TournamentBeginning = e.TournamentBeginning
                });
                return list.ToArray();
            }
        }
        public IEnumerable<TourneyPro_Models.TournamentDetailAndListItem> GetAllActiveTournaments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<TourneyPro_Models.TournamentDetailAndListItem> tournamentList = new List<TourneyPro_Models.TournamentDetailAndListItem>();
                var list = GetAllTournaments();
                var goodList = list.ToList();
                foreach(TourneyPro_Models.TournamentDetailAndListItem item in list)
                {
                    TimeSpan timespan = item.TournamentBeginning - DateTime.Now;
                    if(timespan > DateTime.Now-DateTime.Now)
                    {
                        goodList.Add(item);
                    }
                }
                return goodList;
            }
        }
        public bool UpdateTournament(TourneyPro_Models.TournamentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Tournaments.Where(e => e.Id == model.Id).FirstOrDefault();
                item.Name = model.Name;
                item.TournamentBeginning = model.TournamentBeginning;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTournament(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Tournaments.Where(e => e.Id == id).FirstOrDefault();
                ctx.Tournaments.Remove(item);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
