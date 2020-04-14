using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyPro.Models;
using TourneyPro_Data;
using TourneyPro_Services;

namespace TourneyPro.Controllers
{
    public class SiteUserController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: SiteUser
        public ActionResult Index()
        {
            var list = ctx.SiteUsers.ToList();
            var ordered = list.OrderBy(e => e.Username).ToList();
            return View(ordered);
        }

        //GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SiteUser user = ctx.SiteUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = GetService();
            service.DeleteUser(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SiteUser user = ctx.SiteUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            TourneyPro_Models.SiteUserEdit model = new TourneyPro_Models.SiteUserEdit();
            model.Name = user.Name;
            model.Username = user.Username;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourneyPro_Models.SiteUserEdit model)
        {
            var service = GetService();
            if (ModelState.IsValid)
            {
                var succeeded = service.UpdateUser(model);
                if (succeeded == true)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SiteUser user = ctx.SiteUsers.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            TourneyPro_Models.SiteUserDetail details = new TourneyPro_Models.SiteUserDetail();
            details.Image = user.Image;
            details.Id = user.Id;
            details.Name = user.Name;
            details.Username = user.Username;
            details.IsVerified = user.IsVerified;
            return View(details);
        }
        private SiteUserService GetService()
        {
            var userId = User.Identity.GetUserId();
            var Id = new Guid(userId);
            var service = new SiteUserService(Id);
            return service;
        }
    }
}