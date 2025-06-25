using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index(string arama, int sayfa=1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(d => (d.Aciklama.ToLower().Contains(arama) ) || (d.AltBaslik.ToLower().Contains(arama)) || (d.Baslik.ToLower().Contains(arama)) || (d.Tarih.ToLower().Contains(arama))).OrderBy(y => y.ID)
                .ToPagedList(sayfa, 10);

                return View(degerler);
            }

            else
            {
                var degerler = repo.List().OrderBy(y => y.ID)
                .ToPagedList(sayfa, 10);

                return View(degerler);
            }
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim t)
        {

            if (!ModelState.IsValid)
            {
                return View("DeneyimEkle"); // Hatalarla birlikte formu tekrar göster
            }

            repo.Add(t);

            TempData["SuccessMessage"] = "Deneyim basiryla eklendi";

            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim deneyim = repo.Find(d => d.ID == id);
            repo.TDelete(deneyim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            var deneyim = repo.TGet(id);
            return View(deneyim);
        }

        [HttpPost]
        public ActionResult DeneyimGuncelle(TblDeneyimlerim deneyim)
        {
            if (!ModelState.IsValid)
            {
                return View("DeneyimGetir"); // Hatalarla birlikte formu tekrar göster
            }

            TempData["SuccessMessage"] = "Deneyim basariyla guncellendi";

            var dnym = repo.TGet(deneyim.ID);
            dnym.Baslik = deneyim.Baslik;
            dnym.AltBaslik = deneyim.AltBaslik;
            dnym.Aciklama = deneyim.Aciklama;
            dnym.Tarih = deneyim.Tarih;
            repo.TUpdate(dnym);
            return RedirectToAction("Index");
        }


    }
}