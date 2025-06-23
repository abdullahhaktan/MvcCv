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
    public class YetenekController : Controller
    {
        YetenekRepository repo = new YetenekRepository();
        public ActionResult Index(string arama , int sayfa=1)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(y => (y.Yetenek.ToLower().Contains(arama)) || (y.Oran.ToLower().Contains(arama))).OrderBy(y => y.ID)
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
        public ActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetenekEkle(TblOzelliklerim o)
        {
            if (!ModelState.IsValid)
            {
                return View("YetenekEkle"); // Hatalarla birlikte formu tekrar göster
            }

            repo.Add(o);

            TempData["SuccessMessage"] = "Egitim basariyla eklendi";

            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            TblOzelliklerim ozellik = repo.Find(d => d.ID == id);
            repo.TDelete(ozellik);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OzellikGetir(int id)
        {
            var ozellik = repo.TGet(id);
            return View(ozellik);
        }

        [HttpPost]
        public ActionResult OzellikGuncelle(TblOzelliklerim ozellik)
        {
            if (!ModelState.IsValid)
            {
                return View("DeneyimGetir"); // Hatalarla birlikte formu tekrar göster
            }

            var ozllk = repo.TGet(ozellik.ID);
            ozllk.Yetenek = ozellik.Yetenek;
            ozllk.Oran = ozellik.Oran;
            repo.TUpdate(ozllk);

            TempData["SuccessMessage"] = "Yetenej basariyla guncellendi";


            return RedirectToAction("Index");
        }

    }
}