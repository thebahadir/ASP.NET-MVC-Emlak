using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeEmlak.Models;

namespace ProjeEmlak.Controllers
{
    public class EmlakController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Emlak
        public ActionResult Index()
        {
            var emlaks = db.Emlaks.Include(e => e.Durum);
            return View(emlaks.ToList());
        }
        public PartialViewResult DurumAd1()
        {
            var durumAd1 = db.Emlaks.Where(i => i.DurumId == 1).FirstOrDefault();
            return PartialView(durumAd1);
        }
        public PartialViewResult DurumAd2()
        {
            var durumAd2 = db.Emlaks.Where(i => i.DurumId == 2).FirstOrDefault();
            return PartialView(durumAd2);
        }
        public PartialViewResult DurumEmlak1()
        {
            var durumEmlak1 = db.Emlaks.Where(i => i.DurumId == 1).ToList();
            return PartialView(durumEmlak1);
        }
        public PartialViewResult DurumEmlak2()
        {
            var durumEmlak2 = db.Emlaks.Where(i => i.DurumId == 2).ToList();
            return PartialView(durumEmlak2);
        }
        // GET: Emlak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlak emlak = db.Emlaks.Find(id);
            if (emlak == null)
            {
                return HttpNotFound();
            }
            return View(emlak);
        }

        // GET: Emlak/Create
        public ActionResult Create()
        {
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd");
            return View();
        }

        // POST: Emlak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmlakId,EmlakAd,DurumId")] Emlak emlak)
        {
            if (ModelState.IsValid)
            {
                db.Emlaks.Add(emlak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", emlak.DurumId);
            return View(emlak);
        }

        // GET: Emlak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlak emlak = db.Emlaks.Find(id);
            if (emlak == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", emlak.DurumId);
            return View(emlak);
        }

        // POST: Emlak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmlakId,EmlakAd,DurumId")] Emlak emlak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emlak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurumId = new SelectList(db.Durums, "DurumId", "DurumAd", emlak.DurumId);
            return View(emlak);
        }

        // GET: Emlak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emlak emlak = db.Emlaks.Find(id);
            if (emlak == null)
            {
                return HttpNotFound();
            }
            return View(emlak);
        }

        // POST: Emlak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emlak emlak = db.Emlaks.Find(id);
            db.Emlaks.Remove(emlak);
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
