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
    public class tbl_GroomingServicesController : Controller
    {
        private DGroomingEntities db = new DGroomingEntities();

        // GET: tbl_GroomingServices
        public ActionResult Index()
        {
            return View(db.tbl_GroomingServices.ToList());
        }

        // GET: tbl_GroomingServices/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_GroomingServices tbl_GroomingServices = db.tbl_GroomingServices.Find(id);
            if (tbl_GroomingServices == null)
            {
                return HttpNotFound();
            }
            return View(tbl_GroomingServices);
        }

        // GET: tbl_GroomingServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_GroomingServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,ServiceName,ServiceDuration,ServicePrice")] tbl_GroomingServices tbl_GroomingServices)
        {
            if (ModelState.IsValid)
            {
                db.tbl_GroomingServices.Add(tbl_GroomingServices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_GroomingServices);
        }

        // GET: tbl_GroomingServices/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_GroomingServices tbl_GroomingServices = db.tbl_GroomingServices.Find(id);
            if (tbl_GroomingServices == null)
            {
                return HttpNotFound();
            }
            return View(tbl_GroomingServices);
        }

        // POST: tbl_GroomingServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,ServiceName,ServiceDuration,ServicePrice")] tbl_GroomingServices tbl_GroomingServices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_GroomingServices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_GroomingServices);
        }

        // GET: tbl_GroomingServices/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_GroomingServices tbl_GroomingServices = db.tbl_GroomingServices.Find(id);
            if (tbl_GroomingServices == null)
            {
                return HttpNotFound();
            }
            return View(tbl_GroomingServices);
        }

        // POST: tbl_GroomingServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_GroomingServices tbl_GroomingServices = db.tbl_GroomingServices.Find(id);
            db.tbl_GroomingServices.Remove(tbl_GroomingServices);
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
