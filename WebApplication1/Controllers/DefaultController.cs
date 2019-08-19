using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Home()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View(new ContactFormModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                #region todo if valid
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPServer"]);
                message.To.Add(ConfigurationManager.AppSettings["AdminMail"]);
                message.From = new MailAddress(model.AuthorEmail);
                message.Subject = model.Object;
                message.Body = $"<p> Auteur: {model.AuthorEmail}</p> <p>Contenu: <br/> {model.Content}</p>";

                client.Port = int.Parse(ConfigurationManager.AppSettings["SMTPPort"]);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTPUser"], ConfigurationManager.AppSettings["SMTPPwd"]);

                client.Send(message);
                TempData["SuccessMessage"] = "Votre email a bien été envoyé";
                return RedirectToAction("Home"); 
                #endregion
            }
            ViewBag.ErrorMessage = "Le formulaire n'est pas valide";
            return View(model);
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
    }
}