using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AutoMapper;

namespace Pixel_Art_Blog.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context)
            : base(context)
        {

        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }

        public IEnumerable<Post> GetPostsRange(int page, int size)
        {
            return BlogContext.Posts
                .Include(c => c.Category)
                .OrderBy(c => c.ID)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public void Update(Post post)
        {
            var postInDb = BlogContext.Posts.Single(p => p.ID == post.ID);

            Mapper.Map(post, postInDb);
        }
    }
}