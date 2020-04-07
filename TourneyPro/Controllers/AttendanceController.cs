using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyPro.Models;

namespace TourneyPro.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
    }
}