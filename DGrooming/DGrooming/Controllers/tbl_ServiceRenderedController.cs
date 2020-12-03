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
    public class tbl_ServiceRenderedController : Controller
    {
        private DGroomingEntities db = new DGroomingEntities();

        // GET: tbl_ServiceRendered
        public ActionResult Index()
        {
            var tbl_ServiceRendered = db.tbl_ServiceRendered.Include(t => t.tbl_Appointment).Include(t => t.tbl_Employee).Include(t => t.tbl_GroomingServices);
            return View(tbl_ServiceRendered.ToList());
        }

        // GET: tbl_ServiceRendered/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceRendered tbl_ServiceRendered = db.tbl_ServiceRendered.Find(id);
            if (tbl_ServiceRendered == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceRendered);
        }

        // GET: tbl_ServiceRendered/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentID = new SelectList(db.tbl_Appointment, "AppointmentID", "DogID");
            ViewBag.EmployeeID = new SelectList(db.tbl_Employee, "EmployeeID", "Firstname");
            ViewBag.ServiceID = new SelectList(db.tbl_GroomingServices, "ServiceID", "ServiceName");
            return View();
        }

        // POST: tbl_ServiceRendered/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,LineItemNumber,ServiceID,ServiceExtendedPrice,EmployeeID")] tbl_ServiceRendered tbl_ServiceRendered)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ServiceRendered.Add(tbl_ServiceRendered);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentID = new SelectList(db.tbl_Appointment, "AppointmentID", "DogID", tbl_ServiceRendered.AppointmentID);
            ViewBag.EmployeeID = new SelectList(db.tbl_Employee, "EmployeeID", "Firstname", tbl_ServiceRendered.EmployeeID);
            ViewBag.ServiceID = new SelectList(db.tbl_GroomingServices, "ServiceID", "ServiceName", tbl_ServiceRendered.ServiceID);
            return View(tbl_ServiceRendered);
        }

        // GET: tbl_ServiceRendered/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceRendered tbl_ServiceRendered = db.tbl_ServiceRendered.Find(id);
            if (tbl_ServiceRendered == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentID = new SelectList(db.tbl_Appointment, "AppointmentID", "DogID", tbl_ServiceRendered.AppointmentID);
            ViewBag.EmployeeID = new SelectList(db.tbl_Employee, "EmployeeID", "Firstname", tbl_ServiceRendered.EmployeeID);
            ViewBag.ServiceID = new SelectList(db.tbl_GroomingServices, "ServiceID", "ServiceName", tbl_ServiceRendered.ServiceID);
            return View(tbl_ServiceRendered);
        }

        // POST: tbl_ServiceRendered/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,LineItemNumber,ServiceID,ServiceExtendedPrice,EmployeeID")] tbl_ServiceRendered tbl_ServiceRendered)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ServiceRendered).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentID = new SelectList(db.tbl_Appointment, "AppointmentID", "DogID", tbl_ServiceRendered.AppointmentID);
            ViewBag.EmployeeID = new SelectList(db.tbl_Employee, "EmployeeID", "Firstname", tbl_ServiceRendered.EmployeeID);
            ViewBag.ServiceID = new SelectList(db.tbl_GroomingServices, "ServiceID", "ServiceName", tbl_ServiceRendered.ServiceID);
            return View(tbl_ServiceRendered);
        }

        // GET: tbl_ServiceRendered/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceRendered tbl_ServiceRendered = db.tbl_ServiceRendered.Find(id);
            if (tbl_ServiceRendered == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceRendered);
        }

        // POST: tbl_ServiceRendered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ServiceRendered tbl_ServiceRendered = db.tbl_ServiceRendered.Find(id);
            db.tbl_ServiceRendered.Remove(tbl_ServiceRendered);
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
