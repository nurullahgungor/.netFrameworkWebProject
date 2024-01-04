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
    public class cityGraphsAdminController : Controller
    {
        private AyvaDbContext db = new AyvaDbContext();

        // GET: cityGraphsAdmin
        public ActionResult Index()
        {

            return View(db.cityGraphs.ToList());
        }

        // GET: cityGraphsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityGraph cityGraph = db.cityGraphs.Find(id);
            if (cityGraph == null)
            {
                return HttpNotFound();
            }
            return View(cityGraph);
        }

        // GET: cityGraphsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cityGraphsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,sehir_adi,sehir_veri_1,sehir_veri_2,sehir_veri_3")] cityGraph cityGraph)
        {
            if (ModelState.IsValid)
            {
                db.cityGraphs.Add(cityGraph);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityGraph);
        }

        // GET: cityGraphsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityGraph cityGraph = db.cityGraphs.Find(id);
            if (cityGraph == null)
            {
                return HttpNotFound();
            }
            return View(cityGraph);
        }

        // POST: cityGraphsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,sehir_adi,sehir_veri_1,sehir_veri_2,sehir_veri_3")] cityGraph cityGraph)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityGraph).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityGraph);
        }

        // GET: cityGraphsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cityGraph cityGraph = db.cityGraphs.Find(id);
            if (cityGraph == null)
            {
                return HttpNotFound();
            }
            return View(cityGraph);
        }

        // POST: cityGraphsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cityGraph cityGraph = db.cityGraphs.Find(id);
            db.cityGraphs.Remove(cityGraph);
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
