using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya

        // Repository for social media data operations
        SosyalMedyaRepository repo = new SosyalMedyaRepository();

        // Display social media links with optional search
        public ActionResult Index(string arama)
        {
            // Search functionality by social media name
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(s => (s.Ad.ToLower().Contains(arama)))
                                          .OrderBy(s => s.ID)
                                          .ToList();
                return View(degerler);
            }
            else
            {
                var degerler = repo.List();
                return View(degerler);
            }
        }

        // Display form for adding new social media link (GET)
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }

        // Handle form submission for adding social media link (POST)
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya s)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("YetenekEkle"); // Note: Should be "SosyalMedyaEkle" not "YetenekEkle"
            }

            // Convert social media name to lowercase for consistency
            s.Ad = s.Ad.ToLower();

            // Dictionary mapping social media platform names to Font Awesome icons
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

            // Assign appropriate icon based on platform name
            if (!string.IsNullOrEmpty(s.Ad) && ikonlar.ContainsKey(s.Ad.Trim()))
            {
                s.İkon = ikonlar[s.Ad.Trim().ToLower()];
            }
            else
            {
                s.İkon = "fa fa-globe"; // Default icon for unknown platforms
            }

            // Add new social media link to repository
            repo.Add(s);

            // Set success message
            TempData["SuccessMessage"] = "Sosyal medya basariyla eklendi";

            return RedirectToAction("Index");
        }

        // Delete social media link by ID
        public ActionResult SosyalMedyaSil(int id)
        {
            TblSosyalMedya medya = repo.Find(d => d.ID == id);
            repo.TDelete(medya);
            return RedirectToAction("Index");
        }

        // Display form for updating social media link (GET)
        [HttpGet]
        public ActionResult SosyalMedyaGuncelle(int id)
        {
            var ozellik = repo.TGet(id);
            return View(ozellik);
        }

        // Handle form submission for updating social media link (POST)
        [HttpPost]
        public ActionResult SosyalMedyaGuncelle(TblSosyalMedya medya)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("SosyalMedyaGuncelle", medya.ID); // Return form with validation errors
            }

            // Retrieve existing social media link and update fields
            var mdy = repo.TGet(medya.ID);
            mdy.Ad = medya.Ad;
            mdy.Link = medya.Link;
            repo.TUpdate(mdy);

            // Set success message
            TempData["SuccessMessage"] = "Medya basariyla guncellendi";

            return RedirectToAction("Index");
        }
    }
}