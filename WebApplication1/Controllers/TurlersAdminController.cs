using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TurlersAdminController : Controller
    {
        private AyvaDbContext db = new AyvaDbContext();

        // GET: TurlersAdmin
        public ActionResult Index()
        {
            return View(db.Turlers.ToList());
        }

        // GET: TurlersAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turler turler = db.Turlers.Find(id);
            if (turler == null)
            {
                return HttpNotFound();
            }
            return View(turler);
        }

        // GET: TurlersAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurlersAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tur_adi")] Turler turler)
        {
            if (ModelState.IsValid)
            {
                db.Turlers.Add(turler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turler);
        }

        // GET: TurlersAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turler turler = db.Turlers.Find(id);
            if (turler == null)
            {
                return HttpNotFound();
            }
            return View(turler);
        }

        // POST: TurlersAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tur_adi")] Turler turler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turler);
        }

        // GET: TurlersAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turler turler = db.Turlers.Find(id);
            if (turler == null)
            {
                return HttpNotFound();
            }
            return View(turler);
        }

        // POST: TurlersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turler turler = db.Turlers.Find(id);
            db.Turlers.Remove(turler);
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
