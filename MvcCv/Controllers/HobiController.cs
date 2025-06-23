using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        HobiRepository repo = new HobiRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List().FirstOrDefault();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(TblHobilerim hobi)
        {
            if (!ModelState.IsValid)
            {
                return View(hobi);
            }


            var hob = repo.Find(X => X.ID == hobi.ID);

            hob.Aciklama1 = hobi.Aciklama1;
            hob.Aciklama2 = hobi.Aciklama2;

            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }

    }
}