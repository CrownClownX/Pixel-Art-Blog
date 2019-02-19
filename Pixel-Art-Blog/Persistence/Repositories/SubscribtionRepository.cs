using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence.Repositories
{
    public class SubscribtionRepository : Repository<Subscriber>, ISubscriberRepository
    {
        public SubscribtionRepository(BlogContext context)
            : base(context)
        {

        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }
    }
}