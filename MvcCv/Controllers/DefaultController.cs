using MvcCv.Models.Entity;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
namespace MvcCv.Controllers
{
    [AllowAnonymous] // Allow access without authentication
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities1 db = new DbCvEntities1();

        // Main homepage action
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        // Partial view for social media links
        public PartialViewResult SosyalMedya()
        {
            var degerler = db.TblSosyalMedya.ToList();
            return PartialView(degerler);
        }

        // Partial view for experience section
        public PartialViewResult Deneyim()
        {
            var degerler = db.TblDeneyimlerim.ToList();
            return PartialView(degerler);
        }

        // Partial view for education section
        public PartialViewResult Egitim()
        {
            var degerler = db.TblEgitimlerim.ToList();
            return PartialView(degerler);
        }

        // Partial view for skills section
        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblOzelliklerim.ToList();
            return PartialView(yetenekler);
        }

        // Partial view for hobbies section
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }

        // Partial view for certificates section
        public PartialViewResult Sertfikalarım()
        {
            var serftifikalarım = db.TblSertifikalarım.ToList();
            return PartialView(serftifikalarım);
        }

        // Partial view for contact information
        public PartialViewResult Iletisim()
        {
            var iletisim = db.Tbliletisim.ToList();
            return PartialView(iletisim);
        }

        // Action to handle contact form submission
        public ActionResult MesajGonder(Tbliletisim mesajIcerik)
        {
            // Set current date for the message
            mesajIcerik.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            // Save message to database
            db.Tbliletisim.Add(mesajIcerik);
            db.SaveChanges();

            // Retrieve email configuration from web.config
            string sendTo = ConfigurationManager.AppSettings["SendTo"];
            string mailPassword = ConfigurationManager.AppSettings["MailPassword"];
            string mailHost = ConfigurationManager.AppSettings["SmtpHost"];
            int mailPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);

            string subject = mesajIcerik.Konu;
            string content = mesajIcerik.Mesaj;

            // Configure SMTP client
            var smtp = new SmtpClient
            {
                Host = mailHost,
                Port = mailPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(sendTo, mailPassword)
            };

            // Create email message
            var mail = new MailMessage();
            mail.From = new MailAddress(sendTo, "Web İletişim Formu"); // Must match SMTP credentials
            mail.To.Add(sendTo);
            mail.Subject = mesajIcerik.Konu;
            mail.Body = $"Gönderen: {mesajIcerik.AdSoyad} ({mesajIcerik.Mail})\n\nMesaj:\n{mesajIcerik.Mesaj}";
            mail.ReplyToList.Add(new MailAddress(mesajIcerik.Mail));

            try
            {
                // Send email
                smtp.Send(mail);
                ViewBag.Mesaj = "Mesajınız Başarıyla Gönderilmiştir.";
            }
            catch (Exception ex)
            {
                ViewBag.Mesaj = "Mesajınız Gönderilemedi. Hata: " + ex.Message;
            }

            // Redirect to homepage after submission
            return RedirectToAction("Index");
        }
    }
}