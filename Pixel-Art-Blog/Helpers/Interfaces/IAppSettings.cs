using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Helpers.Interfaces
{
    public interface IAppSettings
    {
        T Setting<T>(string name);
    }
}
