using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Helpers.Interfaces
{
    public interface IEmailManager
    {
        Task EmailSenderAsync(MailMessage message);
    }
}
