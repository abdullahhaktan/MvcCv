using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
       ContactRepository  repo = new ContactRepository();
        public ActionResult Index(string arama, int sayfa = 1)
        {
            var liste = repo.List();

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

            var pagedList = liste
                .OrderByDescending(y => y.Tarih)
                .ToPagedList(sayfa, 10);

            foreach (var item in pagedList)
            {
                item.Tarih = item.Tarih.Value.Date; // Saat: 00:00:00 olur, tip bozulmaz
            }

            return View(pagedList);
        }

        public ActionResult MailSil(int id)
        {
            Tbliletisim mesaj = repo.Find(d => d.Id == id);
            repo.TDelete(mesaj);
            return RedirectToAction("Index");
        }
    }
}