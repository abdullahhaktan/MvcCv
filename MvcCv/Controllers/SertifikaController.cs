using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();

        // Listeleme
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }

        // Silme
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

        // Ekleme (GET)
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        // Ekleme (POST)
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        // Güncelleme (GET)
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        // Güncelleme (POST)
        [HttpPost]
        public ActionResult SertifikaGuncelle(TblSertifikalarım p)
        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
    }
}
