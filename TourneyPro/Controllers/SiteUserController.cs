using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyPro.Models;
using TourneyPro_Data;

namespace TourneyPro.Controllers
{
    public class SiteUserController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: SiteUser
        public ActionResult Index()
        {
            List<SiteUser> unordered = ctx.SiteUsers.ToList();
            List<SiteUser> ordered = unordered.OrderBy(e => e.Username).ToList();
            return View(ordered);
        }

    }
}