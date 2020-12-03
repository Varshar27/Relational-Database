using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGrooming.Models;

namespace DGrooming.Controllers
{
    public class tbl_AppointmentController : Controller
    {
        private DGroomingEntities db = new DGroomingEntities();

        // GET: tbl_Appointment
        public ActionResult Index()
        {
            var tbl_Appointment = db.tbl_Appointment.Include(t => t.tbl_Dog);
            return View(tbl_Appointment.ToList());
        }

        // GET: tbl_Appointment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Appointment tbl_Appointment = db.tbl_Appointment.Find(id);
            if (tbl_Appointment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Appointment);
        }

        // GET: tbl_Appointment/Create
        public ActionResult Create()
        {
            ViewBag.DogID = new SelectList(db.tbl_Dog, "DogID", "OwnerID");
            return View();
        }

        // POST: tbl_Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,AppointmentDate,AppointmentTime,DogID,Cancelled,Cancelled_Reason")] tbl_Appointment tbl_Appointment)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Appointment.Add(tbl_Appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DogID = new SelectList(db.tbl_Dog, "DogID", "OwnerID", tbl_Appointment.DogID);
            return View(tbl_Appointment);
        }

        // GET: tbl_Appointment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Appointment tbl_Appointment = db.tbl_Appointment.Find(id);
            if (tbl_Appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DogID = new SelectList(db.tbl_Dog, "DogID", "OwnerID", tbl_Appointment.DogID);
            return View(tbl_Appointment);
        }

        // POST: tbl_Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,AppointmentDate,AppointmentTime,DogID,Cancelled,Cancelled_Reason")] tbl_Appointment tbl_Appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DogID = new SelectList(db.tbl_Dog, "DogID", "OwnerID", tbl_Appointment.DogID);
            return View(tbl_Appointment);
        }

        // GET: tbl_Appointment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Appointment tbl_Appointment = db.tbl_Appointment.Find(id);
            if (tbl_Appointment == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Appointment);
        }

        // POST: tbl_Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Appointment tbl_Appointment = db.tbl_Appointment.Find(id);
            db.tbl_Appointment.Remove(tbl_Appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
