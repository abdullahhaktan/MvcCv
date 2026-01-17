using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // Repository for skills data operations
        YetenekRepository repo = new YetenekRepository();

        // Display skills with search and pagination (requires authentication)
        [Authorize]
        public ActionResult Index(string arama, int sayfa = 1)
        {
            // Search functionality across skill name and proficiency level
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                var degerler = repo.List().Where(y => (y.Yetenek.ToLower().Contains(arama)) ||
                                                   (y.Oran.ToLower().Contains(arama)))
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

        // Display form for adding new skill (GET)
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        // Handle form submission for adding skill (POST)
        [HttpPost]
        public ActionResult YetenekEkle(TblOzelliklerim o)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View("YetenekEkle"); // Return form with validation errors
            }

            // Add new skill to repository
            repo.Add(o);

            // Set success message (note: message says "Egitim" but should be "Yetenek")
            TempData["SuccessMessage"] = "Egitim basariyla eklendi";

            return RedirectToAction("Index");
        }

        // Delete skill by ID
        public ActionResult YetenekSil(int id)
        {
            TblOzelliklerim ozellik = repo.Find(d => d.ID == id);
            repo.TDelete(ozellik);
            return RedirectToAction("Index");
        }

        // Get skill for editing (GET)
        [HttpGet]
        public ActionResult OzellikGetir(int id)
        {
            var ozellik = repo.TGet(id);
            return View(ozellik);
        }

        // Update skill (POST)
        [HttpPost]
        public ActionResult OzellikGuncelle(TblOzelliklerim ozellik)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                // Note: Should be "OzellikGetir" not "DeneyimGetir"
                return View("DeneyimGetir");
            }

            // Retrieve existing skill and update fields
            var ozllk = repo.TGet(ozellik.ID);
            ozllk.Yetenek = ozellik.Yetenek;
            ozllk.Oran = ozellik.Oran;

            // Update in repository
            repo.TUpdate(ozllk);

            // Set success message (note: typo "Yetenej")
            TempData["SuccessMessage"] = "Yetenej basariyla guncellendi";

            return RedirectToAction("Index");
        }
    }
}