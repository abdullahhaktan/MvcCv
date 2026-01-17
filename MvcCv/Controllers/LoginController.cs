using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous] // Allow access without authentication
    public class LoginController : Controller
    {
        // GET: Login

        // Repository for admin user authentication
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();

        // Display login form (GET)
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Handle login form submission (POST)
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            // Validate model state
            if (ModelState.IsValid)
            {
                // Check if user exists with provided credentials
                var user = repo.Find(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);

                if (user != null)
                {
                    // Authentication successful - create forms authentication ticket
                    FormsAuthentication.SetAuthCookie(user.KullaniciAdi, false); // false = non-persistent cookie

                    // Store username in session for later use
                    Session["KullaniciAdi"] = user.KullaniciAdi;

                    // Redirect to experience management page
                    return RedirectToAction("Index", "Deneyim");
                }
                else
                {
                    // Authentication failed - add error message
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                }
            }

            // Return to login view with validation errors
            return View(admin);
        }

        // Logout action
        public ActionResult LogOut()
        {
            // Clear forms authentication cookie
            FormsAuthentication.SignOut();

            // Abandon current session
            Session.Abandon();

            // Redirect to login page
            return RedirectToAction("Index", "Login");
        }
    }
}