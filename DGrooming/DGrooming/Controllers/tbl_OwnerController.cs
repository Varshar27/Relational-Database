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
    public class tbl_OwnerController : Controller
    {
        private DGroomingEntities db = new DGroomingEntities();

        // GET: tbl_Owner
        public ActionResult Index()
        {
            return View(db.tbl_Owner.ToList());
        }

        // GET: tbl_Owner/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Owner tbl_Owner = db.tbl_Owner.Find(id);
            if (tbl_Owner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Owner);
        }

        // GET: tbl_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerID,FirstName,LastName,Email_Address,Phone_Number,Address,Owner_Reviews")] tbl_Owner tbl_Owner)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Owner.Add(tbl_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Owner);
        }

        // GET: tbl_Owner/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Owner tbl_Owner = db.tbl_Owner.Find(id);
            if (tbl_Owner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Owner);
        }

        // POST: tbl_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerID,FirstName,LastName,Email_Address,Phone_Number,Address,Owner_Reviews")] tbl_Owner tbl_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Owner);
        }

        // GET: tbl_Owner/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Owner tbl_Owner = db.tbl_Owner.Find(id);
            if (tbl_Owner == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Owner);
        }

        // POST: tbl_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Owner tbl_Owner = db.tbl_Owner.Find(id);
            db.tbl_Owner.Remove(tbl_Owner);
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
