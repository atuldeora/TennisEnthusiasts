using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TennisEnthusiasts.Models;

namespace TennisEnthusiasts.Controllers
{
    public class GrandSlamController : Controller
    {
        private TennisEntities db = new TennisEntities();

        // GET: GrandSlam
        public ActionResult Index()
        {
            //returning all records 
            return View(db.GrandSlams.ToList());
        }

        // GET: GrandSlam/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrandSlam grandSlam = db.GrandSlams.Find(id);
            if (grandSlam == null)
            {
                return HttpNotFound();
            }
            return View(grandSlam);
        }

        // GET: GrandSlam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrandSlam/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Winner,RunnerUp,Title,TriumphDate")] GrandSlam grandSlam)
        {
            if (ModelState.IsValid)
            {
                db.GrandSlams.Add(grandSlam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grandSlam);
        }

        // GET: GrandSlam/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrandSlam grandSlam = db.GrandSlams.Find(id);
            if (grandSlam == null)
            {
                return HttpNotFound();
            }
            return View(grandSlam);
        }

        // POST: GrandSlam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Winner,RunnerUp,Title,TriumphDate")] GrandSlam grandSlam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grandSlam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grandSlam);
        }

        // GET: GrandSlam/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrandSlam grandSlam = db.GrandSlams.Find(id);
            if (grandSlam == null)
            {
                return HttpNotFound();
            }
            return View(grandSlam);
        }

        // POST: GrandSlam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrandSlam grandSlam = db.GrandSlams.Find(id);
            db.GrandSlams.Remove(grandSlam);
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
