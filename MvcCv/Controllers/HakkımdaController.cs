using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda

        // Repository for about section data operations
        private readonly HakkımdaRepository _hakkımdaRepository;

        // Constructor with dependency injection pattern
        public HakkımdaController()
        {
            _hakkımdaRepository = new HakkımdaRepository();
        }

        // Display about information (typically single record)
        public ActionResult Index()
        {
            var degerler = _hakkımdaRepository.List().FirstOrDefault();
            return View(degerler);
        }

        // Update about information (POST)
        public ActionResult HakkımdaGuncelle(TblHakkimda hakkimda)
        {
            // Retrieve existing about data
            var hkkmda = _hakkımdaRepository.TGet(hakkimda.ID);

            // Update all fields from the form
            hkkmda.Ad = hakkimda.Ad;
            hkkmda.Soyad = hakkimda.Soyad;
            hkkmda.Adres = hakkimda.Adres;
            hkkmda.Telefon = hakkimda.Telefon;
            hkkmda.Mail = hakkimda.Mail;
            hkkmda.Resim = hakkimda.Resim;
            hkkmda.Aciklama = hakkimda.Aciklama;

            // Save changes to repository
            _hakkımdaRepository.TUpdate(hkkmda);

            // Redirect to index page
            return RedirectToAction("Index");
        }
    }
}