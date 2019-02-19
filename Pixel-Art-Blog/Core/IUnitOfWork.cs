using Pixel_Art_Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Core
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }
        ISubscriberRepository Subscribers { get; }
        int Complete();
    }
}
