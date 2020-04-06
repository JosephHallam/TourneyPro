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
        public bool CreateAttendance(TourneyPro_Models.AttendanceCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Attendance attendance = new Attendance();
                attendance.EventId = model.EventId;
                attendance.SiteUserId = model.SiteUserId;
                attendance.isPlayer = model.IsPlayer;
                attendance.Event = ctx.Events.Where(e => e.Id == attendance.EventId).SingleOrDefault();
                attendance.SiteUser = ctx.SiteUsers.Where(e => e.Id == attendance.SiteUserId).SingleOrDefault();
                ctx.Attendances.Add(attendance);
                return ctx.SaveChanges() == 1;
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
                var item = ctx.Attendances.Where(e => e.Id == model.Id).SingleOrDefault();
                item.SiteUserId = model.SiteUserId;
                item.EventId = model.EventId;
                item.isPlayer = model.IsPlayer;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAttendance(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.Attendances.Where(e => e.Id == id).SingleOrDefault();
                ctx.Attendances.Remove(item);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
