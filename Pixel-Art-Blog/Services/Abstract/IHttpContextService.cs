using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Services.Abstract
{
    public interface IHttpContextService
    {
        string GetMapPath(string path);
    }
}
