using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // Repository for education data operations
        EgitimRepository repo = new EgitimRepository();

        // Main index action with search and pagination
        public ActionResult Index(string arama, int sayfa = 1)
        {
            // Search functionality
            if (!string.IsNullOrEmpty(arama))
            {
                var degerler = repo.List().Where(e => (e.Baslik.Contains(arama)) ||
                                                   (e.Altbaslik1.Contains(arama)) ||
                                                   (e.Tarih.Contains(arama)))
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

        // Display form for adding new education (GET)
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        // Handle form submission for adding education (POST)
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim t)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle"); // Return form with validation errors
            }

            // Add new education to repository
            repo.Add(t);

            // Set success message in TempData
            TempData["SuccessMessage"] = "Egitim basariyla eklendi";

            return RedirectToAction("Index");
        }

        // Delete education by ID
        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim egitim = repo.Find(d => d.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        // Get education for editing (GET)
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = repo.TGet(id);
            return View(egitim);
        }

        // Update education (POST)
        [HttpPost]
        public ActionResult EgitimGuncelle(TblEgitimlerim egitim)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir", egitim); // Return form with validation errors
            }

            // Retrieve existing education and update fields
            var egtm = repo.TGet(egitim.ID);

            egtm.Baslik = egitim.Baslik;
            egtm.Altbaslik1 = egitim.Altbaslik1;
            egtm.AltBaslik2 = egitim.AltBaslik2;
            egtm.GNO = egitim.GNO;
            egtm.Tarih = egitim.Tarih;

            // Update in repository
            repo.TUpdate(egtm);

            // Set success message
            TempData["SuccessMessage"] = "Egitim basariyla guncellendi";

            return RedirectToAction("Index");
        }
    }
}