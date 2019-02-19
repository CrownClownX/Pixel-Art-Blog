using Ninject;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Helpers.Interfaces;
using Pixel_Art_Blog.Persistence;
using Pixel_Art_Blog.Services;
using Pixel_Art_Blog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IImageManager>().To<ImageManager>();
            kernel.Bind<IHttpContextService>().To<HttpContextService>();
            kernel.Bind<IEmailManager>().To<EmailManager>();
        }
    }
}