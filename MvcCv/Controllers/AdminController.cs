using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        // Listeleme
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        // Silme
        public ActionResult AdminSil(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            repo.TDelete(admin);
            return RedirectToAction("Index");
        }

        // Ekleme (GET)
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        // Ekleme (POST)
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin a)
        {
            repo.Add(a);
            return RedirectToAction("Index");
        }

        // Güncelleme (GET)
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            return View(admin);
        }

        // Güncelleme (POST)
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