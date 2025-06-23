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
    public class EgitimController : Controller
    {
        EgitimRepository repo = new EgitimRepository();
        public ActionResult Index(string arama , int sayfa=1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                var degerler = repo.List().Where(e => (e.Baslik.Contains(arama)) || (e.Altbaslik1.Contains(arama)) || (e.Tarih.Contains(arama))).OrderBy(y => y.ID)
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
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle"); // Hatalarla birlikte formu tekrar göster
            }

            repo.Add(t);

            TempData["SuccessMessage"] = "Egitim basariyla eklendi";


            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim egitim = repo.Find(d => d.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.TGet(id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimGuncelle(TblEgitimlerim egitim)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir",egitim); // Hatalarla birlikte formu tekrar göster
            }

            var egtm = repo.TGet(egitim.ID);
            
            egtm.Baslik = egitim.Baslik;
            egtm.Altbaslik1 = egitim.Altbaslik1;
            egtm.AltBaslik2 = egitim.AltBaslik2;
            egtm.GNO = egitim.GNO;
            egtm.Tarih = egitim.Tarih;
            repo.TUpdate(egtm);

            TempData["SuccessMessage"] = "Egitim basariyla guncellendi";


            return RedirectToAction("Index");
        }
    }
}