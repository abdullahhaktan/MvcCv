using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim

        DeneyimRepository repo = new DeneyimRepository();

        // Main index action with search and pagination
        public ActionResult Index(string arama, int sayfa = 1)
        {
            // Search functionality
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                // Search across multiple fields (case-insensitive)
                var degerler = repo.List().Where(d => (d.Aciklama.ToLower().Contains(arama)) ||
                                                   (d.AltBaslik.ToLower().Contains(arama)) ||
                                                   (d.Baslik.ToLower().Contains(arama)) ||
                                                   (d.Tarih.ToLower().Contains(arama)))
                                          .OrderBy(y => y.ID)
                                          .ToPagedList(sayfa, 10); // 10 items per page

                return View(degerler);
            }
            else
            {
                // Default view without search
                var degerler = repo.List().OrderBy(y => y.ID)
                                          .ToPagedList(sayfa, 10);
                return View(degerler);
            }
        }

        // Display form for adding new experience (GET)
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        // Handle form submission for adding experience (POST)
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim t)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("DeneyimEkle"); // Return form with validation errors
            }

            // Add new experience to repository
            repo.Add(t);

            // Set success message in TempData
            TempData["SuccessMessage"] = "Deneyim basiryla eklendi";

            return RedirectToAction("Index");
        }

        // Delete experience by ID
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim deneyim = repo.Find(d => d.ID == id);
            repo.TDelete(deneyim);
            return RedirectToAction("Index");
        }

        // Get experience for editing (GET)
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            var deneyim = repo.TGet(id);
            return View(deneyim);
        }

        // Update experience (POST)
        [HttpPost]
        public ActionResult DeneyimGuncelle(TblDeneyimlerim deneyim)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("DeneyimGetir"); // Return form with validation errors
            }

            // Set success message
            TempData["SuccessMessage"] = "Deneyim basariyla guncellendi";

            // Retrieve existing experience and update fields
            var dnym = repo.TGet(deneyim.ID);
            dnym.Baslik = deneyim.Baslik;
            dnym.AltBaslik = deneyim.AltBaslik;
            dnym.Aciklama = deneyim.Aciklama;
            dnym.Tarih = deneyim.Tarih;

            // Update in repository
            repo.TUpdate(dnym);

            return RedirectToAction("Index");
        }
    }
}