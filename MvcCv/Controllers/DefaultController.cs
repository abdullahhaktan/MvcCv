using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();

            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var degerler = db.TblSosyalMedya.ToList();

            return PartialView(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var degerler = db.TblDeneyimlerim.ToList();

            return PartialView(degerler);
        }

        public PartialViewResult Egitim()
        {
            var degerler = db.TblEgitimlerim.ToList();

            return PartialView(degerler);
        }

        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblOzelliklerim.ToList();

            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();

            return PartialView(hobilerim);
        }

        public PartialViewResult Sertfikalarım()
        {
            var serftifikalarım = db.TblSertifikalarım.ToList();

            return PartialView(serftifikalarım);
        }

        public PartialViewResult Iletisim()
        {
            var iletisim = db.Tbliletisim.ToList();
            return PartialView(iletisim);
        }

        public ActionResult MesajGonder(Tbliletisim mesajIcerik)
        {
            mesajIcerik.Tarih = DateTime.Now;
            db.Tbliletisim.Add(mesajIcerik);
            db.SaveChanges();

            string sendTo = ConfigurationManager.AppSettings["SendTo"];
            string mailPassword = ConfigurationManager.AppSettings["MailPassword"];
            string mailHost = ConfigurationManager.AppSettings["SmtpHost"];
            int mailPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);

            string subject = mesajIcerik.Konu;
            string content = mesajIcerik.Mesaj;

            var smtp = new SmtpClient
            {
                Host = mailHost,
                Port = mailPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sendTo, mailPassword)
            };

            var mail = new MailMessage();
            mail.From = new MailAddress(sendTo, "Web İletişim Formu"); // SMTP’ye uygun
            mail.To.Add(sendTo);
            mail.Subject = mesajIcerik.Konu;
            mail.Body = $"Gönderen: {mesajIcerik.AdSoyad} ({mesajIcerik.Mail})\n\nMesaj:\n{mesajIcerik.Mesaj}";
            mail.ReplyToList.Add(new MailAddress(mesajIcerik.Mail));


            try
            {
                smtp.Send(mail);
                ViewBag.Mesaj = "Mesajınız Başarıyla Gönderilmiştir.";
            }
            catch (Exception ex)
            {
                ViewBag.Mesaj = "Mesajınız Gönderilemedi. Hata: " + ex.Message;
            }
            return RedirectToAction("Index");

        }
    }
}