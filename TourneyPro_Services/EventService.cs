using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourneyPro.Models;
using TourneyPro_Data;

namespace TourneyPro_Services
{
    public class EventService
    {
        public Guid _userId;
        public EventService(Guid id)
        {
            _userId = id;
        }
        public bool CreateEvent(TourneyPro_Models.EventCreateAndEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Event item = new Event();
                item.Name = model.Name;
                item.GamePlayed = model.GamePlayed;
                item.Description = model.Description;
                item.TournamentId = model.TournamentId;
                item.Tournament = ctx.Tournaments.Where(e => e.Id == item.TournamentId).SingleOrDefault();
                item.Payout = model.Payout;
                item.EventFee = model.EventFee;
                item.EventBeginning = model.EventBeginning;
                ctx.Events.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TourneyPro_Models.EventListItem> GetEventsForTournament(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Events.Where(e => e.TournamentId == id).Select(e => new TourneyPro_Models.EventListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    EventBeginning = e.EventBeginning
                });
                return list.ToArray();
            }
        }
        public bool UpdateEvent(TourneyPro_Models.EventCreateAndEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Events.Where(e => e.Id == model.Id).SingleOrDefault();
                item.Name = model.Name;
                item.GamePlayed = model.GamePlayed;
                item.Description = model.Description;
                item.TournamentId = model.TournamentId;
                item.Payout = model.Payout;
                item.EventFee = model.EventFee;
                item.EventBeginning = model.EventBeginning;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEvent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Events.Where(e => e.Id == id).SingleOrDefault();
                ctx.Events.Remove(item);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
