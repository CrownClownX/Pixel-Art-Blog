using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Repositories;
using Pixel_Art_Blog.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
            Posts = new PostRepository(context);
            Categories = new CategoryRepository(context);
        }

        public IPostRepository Posts { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}