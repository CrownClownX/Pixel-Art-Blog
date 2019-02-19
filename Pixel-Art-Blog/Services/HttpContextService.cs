using Pixel_Art_Blog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Services
{
    public class HttpContextService : IHttpContextService
    {
        public string GetMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}