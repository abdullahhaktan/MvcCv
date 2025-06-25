using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            if (ModelState.IsValid)
            {

              var user = repo.Find(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);
              if (user != null)
              {
                    FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false);
                    Session["KullaniciAdi"] = user.KullaniciAdi;
                 return RedirectToAction("Index", "Deneyim");
              }

              else
              {
                 ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
              }   
                
            }
            return View(admin);
        }

        public ActionResult LogOut()
        {   
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}