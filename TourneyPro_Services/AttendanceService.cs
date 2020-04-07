using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourneyPro.Models;
using TourneyPro_Data;

namespace TourneyPro_Services
{
    public class AttendanceService
    {
        public Guid _userId;
        public AttendanceService(Guid id)
        {
            _userId = id;
        }
        public bool CreateAttendance(Attendance model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    model.Event = ctx.Events.Where(e => e.Id == model.EventId).SingleOrDefault();
                    model.SiteUser = ctx.SiteUsers.Where(e => e.Id == model.SiteUserId).SingleOrDefault();
                    ctx.Attendances.Add(model);
                    return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        public IEnumerable<TourneyPro_Models.AttendanceDetailAndListItem> GetAllAttendancesForPlayer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Attendances.Where(e => e.SiteUserId == id).Select(e => new TourneyPro_Models.AttendanceDetailAndListItem
                {
                    Id = e.Id,
                    EventName = e.Event.Name,
                    SiteUserName = e.SiteUser.Username,
                    IsPlayer = e.isPlayer
                });
                return list.ToArray();
            }
        }
        public IEnumerable<TourneyPro_Models.AttendanceDetailAndListItem> GetAllAttendeesOfAnEvent(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Attendances.Where(e => e.EventId == id).Select(e => new TourneyPro_Models.AttendanceDetailAndListItem
                {
                    Id = e.Id,
                    EventName = e.Event.Name,
                    SiteUserName = e.SiteUser.Username,
                    IsPlayer = e.isPlayer
                });
                return list.ToArray();
            }
        }
        public bool UpdateAttendance(TourneyPro_Models.AttendanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {

                    var item = ctx.Attendances.Where(e => e.Id == model.Id).SingleOrDefault();
                    item.SiteUserId = model.SiteUserId;
                    item.EventId = model.EventId;
                    item.isPlayer = model.IsPlayer;
                    return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteAttendance(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {

                    var item = ctx.Attendances.Where(e => e.Id == id).SingleOrDefault();
                    ctx.Attendances.Remove(item);
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
