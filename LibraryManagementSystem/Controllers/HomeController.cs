using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.EmailService;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IMailService MailService { get; set; }
        public EMailSettings mailSettings { get; set; }

        public HomeController()
        {
            if (MailService == null)
            {
                mailSettings = new EMailSettings();
                mailSettings.APIKey = ConfigurationManager.AppSettings["SendGridApiKey"].ToString();
                mailSettings.FromMailId = ConfigurationManager.AppSettings["FromEmail"].ToString();
                mailSettings.FromMailName = ConfigurationManager.AppSettings["FromEmailName"].ToString();

                MailService = new SendGridMailService(mailSettings);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        public async Task<ActionResult> Contact(ContactModel contact)
        {
            try
            {
                var subject = contact.name + " Has a Message Request";
                var message = contact.message + "<br/><br/>Requesting Email " + "<b>" + contact.email + "</b>";
                var result = await MailService.SendMailAsync("uldindrajith@yahoo.com", contact.email, subject, message);
                TempData["msg"] = "Your Message Has Been Sent!";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Contact");
        }
    }
}