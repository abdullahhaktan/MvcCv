using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // Repository for certificate data operations
        SertifikaRepository repo = new SertifikaRepository();

        // List all certificates
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }

        // Delete certificate by ID
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }

        // Display form for adding new certificate (GET)
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        // Handle form submission for adding certificate (POST)
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        // Display form for updating certificate (GET)
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }

        // Handle form submission for updating certificate (POST)
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