using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pixel_Art_Blog.Startup))]
namespace Pixel_Art_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
