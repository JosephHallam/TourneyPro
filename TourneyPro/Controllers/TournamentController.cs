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
    public class TournamentController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Tournament
        public ActionResult Index(string searchString)
        {
            var service = GetService();
            if (!String.IsNullOrEmpty(searchString))
            {
                var list = ctx.Tournaments.Where(e => e.Name.Contains(searchString));
                var orderedList = list.OrderBy(e => e.TournamentBeginning).ToList();
                return View(orderedList);
            }
            var array = service.GetAllActiveTournaments();
            var ordered = array.OrderBy(e => e.TournamentBeginning).ToList();
            return View(ordered);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TourneyPro_Models.TournamentCreate model)
        {
            if (ModelState.IsValid)
            {
                var item = new Tournament();
                item.Name = model.Name;
                item.TrailerEmbedLink = model.TrailerEmbedLink;
                item.TournamentBeginning = model.TournamentBeginning;
                ctx.Tournaments.Add(item);
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
            Tournament tournament = ctx.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = GetService();
            var succeeded = service.DeleteTournament(id);
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
            Tournament tournament = ctx.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourneyPro_Models.TournamentEdit model)
        {
            var service = GetService();
            var succeeded = service.UpdateTournament(model);
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
            Tournament tournament = ctx.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }
        private TournamentService GetService()
        {
            var userId = User.Identity.GetUserId();
            var Id = new Guid(userId);
            if(Id == null)
            {
                var badGuid = new Guid();
                return new TournamentService(badGuid);
            }
            var service = new TournamentService(Id);
            return service;
        }
    }
}