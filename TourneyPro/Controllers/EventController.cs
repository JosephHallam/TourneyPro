using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyPro.Models;
using TourneyPro_Data;
using TourneyPro_Services;

namespace TourneyPro.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            var service = GetService();
            var unordered = service.GetAllEvents();
            var ordered = unordered.OrderBy(e => e.EventBeginning).ToList();
            return View(ordered);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                var nameList = new List<string>();
                var list = ctx.Events.Where(e => e.TournamentId == model.TournamentId).ToList();
                foreach(Event item in list)
                {
                    nameList.Add(item.Name);
                }
                var nameString = string.Join(", ", nameList);
                Tournament tournament = ctx.Tournaments.Find(model.TournamentId);
                if(tournament == null)
                {
                    return View(model);
                }
                model.TournamentName = model.Tournament.Name;
                tournament.ListOfEventNames = nameString;
                ctx.Events.Add(model);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Event x = ctx.Events.Find(id);
            if(x == null)
            {
                return HttpNotFound();
            }
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = GetService();
            var succeeded = service.DeleteEvent(id);
            if (succeeded)
            {
            return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Event x = ctx.Events.Find(id);
            if (x == null)
            {
                return HttpNotFound();
            }
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event x)
        {
            var model = new TourneyPro_Models.EventCreateAndEdit();
            model.Description = x.Description;
            model.EventBeginning = x.EventBeginning;
            model.EventFee = x.EventFee;
            model.GamePlayed = x.GamePlayed;
            model.Id = x.Id;
            model.Name = x.Name;
            model.Payout = x.Payout;
            model.TournamentId = x.TournamentId;
            var service = GetService();
            var succeeded = service.UpdateEvent(model);
            if (succeeded)
            {
                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Event x = ctx.Events.Find(id);
            if(x == null)
            {
                return HttpNotFound();
            }
            return View(x);
        }
        private EventService GetService()
        {
            var userId = User.Identity.GetUserId();
            var Id = new Guid(userId);
            var service = new EventService(Id);
            return service;
        }
    }
}