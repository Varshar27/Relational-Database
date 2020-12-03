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
    public class tbl_DogController : Controller
    {
        private DGroomingEntities db = new DGroomingEntities();

        // GET: tbl_Dog
        public ActionResult Index()
        {
            var tbl_Dog = db.tbl_Dog.Include(t => t.tbl_Owner);
            return View(tbl_Dog.ToList());
        }

        // GET: tbl_Dog/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dog tbl_Dog = db.tbl_Dog.Find(id);
            if (tbl_Dog == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dog);
        }

        // GET: tbl_Dog/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.tbl_Owner, "OwnerID", "FirstName");
            return View();
        }

        // POST: tbl_Dog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogID,OwnerID,Dogname,Gender,Breed,DOB,Age,Matted_dog")] tbl_Dog tbl_Dog)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Dog.Add(tbl_Dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.tbl_Owner, "OwnerID", "FirstName", tbl_Dog.OwnerID);
            return View(tbl_Dog);
        }

        // GET: tbl_Dog/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dog tbl_Dog = db.tbl_Dog.Find(id);
            if (tbl_Dog == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.tbl_Owner, "OwnerID", "FirstName", tbl_Dog.OwnerID);
            return View(tbl_Dog);
        }

        // POST: tbl_Dog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogID,OwnerID,Dogname,Gender,Breed,DOB,Age,Matted_dog")] tbl_Dog tbl_Dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.tbl_Owner, "OwnerID", "FirstName", tbl_Dog.OwnerID);
            return View(tbl_Dog);
        }

        // GET: tbl_Dog/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Dog tbl_Dog = db.tbl_Dog.Find(id);
            if (tbl_Dog == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Dog);
        }

        // POST: tbl_Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Dog tbl_Dog = db.tbl_Dog.Find(id);
            db.tbl_Dog.Remove(tbl_Dog);
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
