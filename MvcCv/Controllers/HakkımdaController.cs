using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda

        private readonly HakkımdaRepository _hakkımdaRepository;

        public HakkımdaController()
        {
            _hakkımdaRepository = new HakkımdaRepository();
        }

        public ActionResult Index()
        {
            var degerler = _hakkımdaRepository.List().FirstOrDefault();
            return View(degerler);
        }

        public ActionResult HakkımdaGuncelle(TblHakkimda hakkimda)
        {
            var hkkmda = _hakkımdaRepository.TGet(hakkimda.ID);

            hkkmda.Ad = hakkimda.Ad;
            hkkmda.Soyad = hakkimda.Soyad;
            hkkmda.Adres = hakkimda.Adres;
            hkkmda.Telefon = hakkimda.Telefon;
            hkkmda.Mail = hakkimda.Mail;
            hkkmda.Resim = hakkimda.Resim;
            hkkmda.Aciklama = hakkimda.Aciklama;
        

            _hakkımdaRepository.TUpdate(hkkmda);
            return RedirectToAction("Index");
        }
            
    }
}