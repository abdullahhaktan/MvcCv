using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // Repository for contact messages data operations
        ContactRepository repo = new ContactRepository();

        // Display contact messages with search and pagination
        public ActionResult Index(string arama, int sayfa = 1)
        {
            var liste = repo.List();

            // Search functionality across multiple fields
            if (!string.IsNullOrEmpty(arama))
            {
                arama = arama.ToLower();
                liste = liste.Where(y =>
                    (y.Konu != null && y.Konu.ToLower().Contains(arama)) ||
                    (y.Mail != null && y.Mail.ToLower().Contains(arama)) ||
                    (y.Mesaj != null && y.Mesaj.ToLower().Contains(arama)) ||
                    y.Tarih.ToString().ToLower().Contains(arama)
                ).ToList();
            }

            // Apply pagination (10 items per page) with newest messages first
            var pagedList = liste
                .OrderByDescending(y => y.Tarih)
                .ToPagedList(sayfa, 10);

            // Remove time portion from dates for display purposes
            foreach (var item in pagedList)
            {
                item.Tarih = item.Tarih.Value.Date; // Sets time to 00:00:00, doesn't break type
            }

            return View(pagedList);
        }

        // Delete contact message by ID
        public ActionResult MailSil(int id)
        {
            Tbliletisim mesaj = repo.Find(d => d.Id == id);
            repo.TDelete(mesaj);
            return RedirectToAction("Index");
        }
    }
}