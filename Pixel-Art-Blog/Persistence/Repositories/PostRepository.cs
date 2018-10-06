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

        public IEnumerable<Post> GetPostsRangeWithCategory(int page, int size, int categoryID)
        {
            return BlogContext.Posts
                .Where(c => c.CategoryID == categoryID)
                .Include(c => c.Category)
                .OrderBy(c => c.ID)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public void Save(Post post)
        {
            if(post.ID == 0)
            {
                post.ReleaseDate = DateTime.Now;
                Add(post);

                return;
            }

            var postInDb = BlogContext.Posts.Single(p => p.ID == post.ID);

            postInDb.Title = post.Title;
            postInDb.Description = post.Description;
            postInDb.Content = post.Content;
            postInDb.CategoryID = post.CategoryID;
            postInDb.Img = post.Img ?? postInDb.Img;
        }
    }
}