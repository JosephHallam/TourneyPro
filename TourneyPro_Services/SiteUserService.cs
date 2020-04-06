using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourneyPro.Models;
using TourneyPro_Data;
using TourneyPro_Models;

namespace TourneyPro_Services
{
    public class SiteUserService
    {
        public Guid _userId;
        public SiteUserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSiteUser(SiteUserCreate model)
        {
            var user = new SiteUser()
            {
                Name = model.Name,
                Username = model.Username,
                BirthDate = model.BirthDate,
                IsVerified = false,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SiteUsers.Add(user);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SiteUserListItem> GetAllUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.SiteUsers.Where(e => e.Id != 0).Select(e => new SiteUserListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    Username = e.Username
                });
                return list.ToArray();
            }
        }
        public SiteUserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.SiteUsers.Where(e => e.Id == id).SingleOrDefault();
                var detail = new SiteUserDetail
                {
                    Id = item.Id,
                    IsVerified = item.IsVerified,
                    Name = item.Name,
                    Username = item.Username
                };
                return detail;
            }
        }
        public bool DeleteUser(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.SiteUsers.Where(e => e.Id == id).SingleOrDefault();
                ctx.SiteUsers.Remove(item);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdateUser(SiteUserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var item = ctx.SiteUsers.Where(e => e.Id == model.Id).SingleOrDefault();
                item.Name = model.Name;
                item.Username = model.Username;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
