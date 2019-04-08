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
        private IAppSettings _appSettings;

        private string _userName;
        private string _password;
        private string _host;
        private int _port;
        private bool _enableSsl;

        public EmailManager(IAppSettings appSettings)
        {
            _appSettings = appSettings;

            try
            {
                _userName = _appSettings.Setting<string>("mailAccount");
                _password = _appSettings.Setting<string>("mailPassword");
                _host = _appSettings.Setting<string>("host");
                _port = _appSettings.Setting<int>("port");
                _enableSsl = _appSettings.Setting<bool>("enableSsl");
            }
            catch(Exception e)
            {
                throw e;
            }
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