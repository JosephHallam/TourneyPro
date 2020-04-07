﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourneyPro.Models;
using TourneyPro_Data;
using TourneyPro_Models;
using TourneyPro_Services;

namespace TourneyPro.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: Attendance
        public ActionResult Index()
        {
            var list = ctx.Attendances.ToList();
            var ordered = list.OrderBy(e => e.Id).ToList();
            return View(ordered);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Attendance model)
        {
            var service = GetService();
            if (ModelState.IsValid)
            {
                var succeeded = service.CreateAttendance(model);
                if (succeeded)
                {
                    return RedirectToAction("Index");
                }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Attendance a = ctx.Attendances.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = GetService();
            var works = service.DeleteAttendance(id);
            if (works)
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
            Attendance a = ctx.Attendances.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attendance a)
        {
            var service = GetService();
            var model = new AttendanceEdit();
            model.Id = a.Id;
            model.EventId = a.EventId;
            model.IsPlayer = a.isPlayer;
            model.SiteUserId = a.SiteUserId;
            var works = service.UpdateAttendance(model);
            if (works)
            {
                return RedirectToAction("Index");
            }
            return View(a);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Attendance a = ctx.Attendances.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }
        private AttendanceService GetService()
        {
            var userId = User.Identity.GetUserId();
            var Id = new Guid(userId);
            var service = new AttendanceService(Id);
            return service;
        }
    }
}