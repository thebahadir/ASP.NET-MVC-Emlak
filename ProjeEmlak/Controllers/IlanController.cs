using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjeEmlak.Models;

namespace ProjeEmlak.Controllers
{
    public class IlanController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ilan
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var ilans = db.Ilans.Where(x => x.KullaniciAdi == username).Include(i => i.Emlak).Include(i => i.Mahalle);
            return View(ilans.ToList());
        }

        public List<Sehir> SehirGetir()
        {
            List<Sehir> sehirler = db.Sehirs.ToList();
            return sehirler;
        }

        public ActionResult SemtGetir(int SehirId)
        {
            List<Semt> semtler = db.Semts.Where(x => x.SehirId == SehirId).ToList();
            ViewBag.semtlistesi = new SelectList(semtler, "SemtId", "SemtAd");
            return PartialView("SemtPartial");
        }

        public ActionResult MahalleGetir(int SemtId)
        {
            List<Mahalle> mahalleler = db.Mahalles.Where(x => x.SemtId == SemtId).ToList();
            ViewBag.mahallelist = new SelectList(mahalleler, "MahalleId", "MahalleAd");
            return PartialView("MahallePartial");
        }
        public List<Durum> DurumGetir()
        {
            List<Durum> durumlar = db.Durums.ToList();
            return durumlar;
        }
        public ActionResult EmlakGetir(int DurumId)
        {
            List<Emlak> emlaklist = db.Emlaks.Where(x => x.DurumId == DurumId).ToList();
            ViewBag.emlaklistesi = new SelectList(emlaklist, "EmlakId", "EmlakAd");
            return PartialView("EmlakPartial");
        }
        public ActionResult Images(int Id)
        {
            var ilan = db.Ilans.Where(x => x.IlanId == Id).ToList();
            var rsml = db.Resims.Where(x => x.IlanId == Id).ToList();
            ViewBag.rsml = rsml;
            ViewBag.ilan = ilan;
            return View();
        }
        [HttpPost]
        public ActionResult Images(int Id, HttpPostedFileBase file)
        {
            string path = Path.Combine("/Content/images/" + file.FileName);
            file.SaveAs(Server.MapPath(path));
            Resim rsm = new Resim();
            rsm.ResimAd = file.FileName.ToString();
            rsm.IlanId = Id;
            db.Resims.Add(rsm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Ilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Ilan/Create
        public ActionResult Create()
        {
            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlanId,Aciklama,Fiyat,OdaSayisi,BanyoSayisi,Kredi,Alan,Kat,Isitma,Telefon,Adres,KullaniciAdi,SehirId,SemtId,DurumId,MahalleId,EmlakId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                ilan.KullaniciAdi = User.Identity.Name;
                db.Ilans.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");
            ViewBag.SemtId = new SelectList(db.Semts, "SemtId", "SemtAd", ilan.SemtId);
            ViewBag.MahalleId = new SelectList(db.Mahalles, "MahalleId", "MahalleAd", ilan.MahalleId);
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            ViewBag.EmlakId = new SelectList(db.Emlaks, "EmlakId", "EmlakAd", ilan.EmlakId);
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlanId,Aciklama,Fiyat,OdaSayisi,BanyoSayisi,Kredi,Alan,Kat,Isitma,Telefon,Adres,KullaniciAdi,SehirId,SemtId,DurumId,MahalleId,EmlakId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilans.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilans.Find(id);
            db.Ilans.Remove(ilan);
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
