using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Helpers.Interfaces;
using Pixel_Art_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Controllers
{
    public class ContactController : Controller
    {
        private IEmailManager _emailManager;

        public ContactController(IEmailManager emailManager)
        {
            _emailManager = emailManager;
        }

        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendMessage(ContactViewModel contactForm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Contact");
            }

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>"; ;
            var message = new MailMessage();
            message.To.Add(new MailAddress("hamerlamateusz@gmail.com"));  // replace with valid value 
            message.From = new MailAddress(contactForm.Email);  // replace with valid value
            message.Subject = "Contact Form - Question";
            message.Body = string.Format(body, "User", contactForm.Email, contactForm.Text);
            message.IsBodyHtml = true;

            try
            {
                await _emailManager.EmailSenderAsync(message);
            }
            catch(Exception e)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Post");
        }
    }
}