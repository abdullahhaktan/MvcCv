using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;


namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        SosyalMedyaRepository repo = new SosyalMedyaRepository();
        public ActionResult Index(string arama, int sayfa = 1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(y => (y.Ad.ToLower().Contains(arama))).OrderBy(y => y.ID)
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
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya s)
        {
            if (!ModelState.IsValid)
            {
                return View("YetenekEkle"); // Hatalarla birlikte formu tekrar göster
            }

            repo.Add(s);

            TempData["SuccessMessage"] = "Sosyal medya basariyla eklendi";

            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya medya = repo.Find(d => d.ID == id);
            repo.TDelete(medya);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaGuncelle(int id)
        {
            var ozellik = repo.TGet(id);
            return View(ozellik);
        }

        [HttpPost]
        public ActionResult SosyalMedyaGuncelle(TblSosyalMedya medya)
        {
            if (!ModelState.IsValid)
            {
                return View("DeneyimGetir"); // Hatalarla birlikte formu tekrar göster
            }

            var mdy = repo.TGet(medya.ID);
            mdy.Ad = medya.Ad;
            repo.TUpdate(mdy);

            TempData["SuccessMessage"] = "Medya basariyla guncellendi";


            return RedirectToAction("Index");
        }
    }
}