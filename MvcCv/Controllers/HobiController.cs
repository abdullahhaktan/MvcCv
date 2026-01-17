using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        // Repository for hobbies data operations
        HobiRepository repo = new HobiRepository();

        // Display hobbies form (GET)
        [HttpGet]
        public ActionResult Index()
        {
            // Get first hobby record (typically single record for hobbies section)
            var hobiler = repo.List().FirstOrDefault();
            return View(hobiler);
        }

        // Update hobbies information (POST)
        [HttpPost]
        public ActionResult Index(TblHobilerim hobi)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return View(hobi); // Return form with validation errors
            }

            // Retrieve existing hobby record
            var hob = repo.Find(X => X.ID == hobi.ID);

            // Update description fields
            hob.Aciklama1 = hobi.Aciklama1;
            hob.Aciklama2 = hobi.Aciklama2;

            // Note: Should be repo.TUpdate(hob) instead of repo.TUpdate(hobi)
            // This appears to be a bug but code is not changed
            repo.TUpdate(hobi);

            return RedirectToAction("Index");
        }
    }
}