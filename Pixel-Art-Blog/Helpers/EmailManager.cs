using Pixel_Art_Blog.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Pixel_Art_Blog.Helpers
{
    public class EmailManager : IEmailManager
    {
        private string _userName;
        private string _password;
        private string _host;
        private int _port;
        private bool _enableSsl;

        public EmailManager()
        {
            _userName = AppSettings.Setting<string>("mailAccount");
            _password = AppSettings.Setting<string>("mailPassword");
            _host = AppSettings.Setting<string>("host");
            _port = AppSettings.Setting<int>("port");
            _enableSsl = AppSettings.Setting<bool>("enableSsl");
        }

        public async Task EmailSenderAsync(MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _userName,  
                    Password = _password  
                };
                smtp.Credentials = credential;
                smtp.Host = _host;
                smtp.Port = _port;
                smtp.EnableSsl = _enableSsl;
                await smtp.SendMailAsync(message);
            }
        }
    }
}