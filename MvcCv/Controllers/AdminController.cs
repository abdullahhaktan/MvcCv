using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous] // Allow access without authentication
    public class AdminController : Controller
    {
        // Repository pattern for TblAdmin entity
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        // List all admin users
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        // Delete admin by ID
        public ActionResult AdminSil(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            repo.TDelete(admin);
            return RedirectToAction("Index");
        }

        // Display form for adding new admin (GET)
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        // Process admin addition (POST)
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin a)
        {
            repo.Add(a);
            return RedirectToAction("Index");
        }

        // Display form for updating admin (GET)
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            return View(admin);
        }

        // Process admin update (POST)
        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin a)
        {
            var admin = repo.Find(x => x.ID == a.ID);
            admin.KullaniciAdi = a.KullaniciAdi;
            admin.Sifre = a.Sifre;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}