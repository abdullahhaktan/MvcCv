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
        public ActionResult Index(string arama)
        {
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(s => (s.Ad.ToLower().Contains(arama))).OrderBy(s => s.ID).ToList();
                return View(degerler);
            }
            else
            {
               var degerler  = repo.List();
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

            s.Ad = s.Ad.ToLower();

            var ikonlar = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "instagram", "fa fa-instagram" },
                { "facebook", "fa fa-facebook" },
                { "twitter", "fa fa-twitter" },
                { "linkedin", "fa fa-linkedin" },
                { "youtube", "fa fa-youtube" },
                { "github", "fa fa-github" },
                { "tiktok", "fa fa-tiktok" },
                { "pinterest", "fa fa-pinterest" },
                { "snapchat", "fa fa-snapchat" },
                { "telegram", "fa fa-telegram" },
                { "reddit", "fa fa-reddit" },
                { "tumblr", "fa fa-tumblr" },
                { "medium", "fa fa-medium" },
            };

            if (!string.IsNullOrEmpty(s.Ad) && ikonlar.ContainsKey(s.Ad.Trim()))
            {
                s.İkon = ikonlar[s.Ad.Trim().ToLower()];
            }
            else
            {
                s.İkon = "fa fa-globe"; // bilinmeyen platform için varsayılan ikon
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
                return View("SosyalMedyaGuncelle",medya.ID); // Hatalarla birlikte formu tekrar göster
            }

            var mdy = repo.TGet(medya.ID);
            mdy.Ad = medya.Ad;
            mdy.Link = medya.Link;
            repo.TUpdate(mdy);

            TempData["SuccessMessage"] = "Medya basariyla guncellendi";


            return RedirectToAction("Index");
        }
    }
}