using ProjeEmlak.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace ProjeEmlak.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index(int sayi = 1)
        {
            var img = db.Resims.ToList();
            ViewBag.img = img;
            var ilan = db.Ilans.Include(m => m.Mahalle).Include(e => e.Emlak);
            return View(ilan.ToList().ToPagedList(sayi, 8));
        }
        public ActionResult DurumList(int Id)
        {
            var img = db.Resims.ToList();
            ViewBag.img = img;
            var ilan = db.Ilans.Where(i => i.DurumId == Id).Include(m => m.Mahalle).Include(e => e.Emlak);
            return View(ilan.ToList());
        }
        public ActionResult Menu(int Id)
        {
            var img = db.Resims.ToList();
            ViewBag.img = img;
            var filtre = db.Ilans.Where(i => i.EmlakId == Id).Include(m => m.Mahalle).Include(e => e.Emlak).ToList();
            return View(filtre);
        }
        public PartialViewResult PartialFiltre()
        {
            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");
            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return PartialView();
        }
        public ActionResult Filtre(double min, double max, int sehirId, int semtId, int mahalleId, int durumId, int emlakId)
        {
            var img = db.Resims.ToList();
            ViewBag.img = img;
            var filtre = db.Ilans.Where(i => i.Fiyat >= min && i.Fiyat <= max
            && i.SehirId == sehirId
            && i.SemtId == semtId
            && i.MahalleId == mahalleId
            && i.DurumId== durumId
            && i.EmlakId == emlakId).Include(m => m.Mahalle).Include(e => e.Emlak).ToList();
            return View(filtre);
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
        public ActionResult Search(string q)
        {
            var img = db.Resims.ToList();
            ViewBag.img = img;
            var ara = db.Ilans.Include(m => m.Mahalle).Include(e => e.Emlak);
            if (!string.IsNullOrEmpty(q))
            {
                ara = ara.Where(i => i.Aciklama.Contains(q) || i.Mahalle.MahalleAd.Contains(q) || i.Mahalle.Semt.SemtAd.Contains(q) || i.Mahalle.Semt.Sehir.SehirAd.Contains(q) || i.Emlak.EmlakAd.Contains(q) || i.Emlak.Durum.DurumAd.Contains(q));
            }
            return View(ara.ToList());
        }
        public ActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId == id).Include(m => m.Mahalle).Include(e => e.Emlak).FirstOrDefault();
            var img = db.Resims.Where(i => i.IlanId == id).ToList();
            ViewBag.img = img;
            return View(ilan);
        }
        public PartialViewResult Slider()
        {
            var ilan = db.Ilans.ToList().Take(5);
            var img = db.Resims.ToList();
            ViewBag.img = img;
            return PartialView(ilan);
        }
    }
}