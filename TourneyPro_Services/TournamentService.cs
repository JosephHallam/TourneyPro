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
                try
                {

                var tournament = new Tournament()
                {
                    Name = model.Name,
                    TournamentBeginning = model.TournamentBeginning,
                };
                ctx.Tournaments.Add(tournament);
                return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        public IEnumerable<Tournament> GetAllTournaments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Tournaments.Where(e => e.Id != 0);
                return list.ToArray();
            }
        }
        public IEnumerable<Tournament> GetAllActiveTournaments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<TourneyPro_Models.TournamentDetailAndListItem> tournamentList = new List<TourneyPro_Models.TournamentDetailAndListItem>();
                var list = GetAllTournaments();
                var goodList = list.ToList();
                foreach(Tournament item in list)
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
                try
                {
                var item = ctx.Tournaments.Where(e => e.Id == model.Id).FirstOrDefault();
                item.Name = model.Name;
                item.TournamentBeginning = model.TournamentBeginning;
                return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteTournament(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {

                var item = ctx.Tournaments.Where(e => e.Id == id).FirstOrDefault();
                ctx.Tournaments.Remove(item);
                return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
