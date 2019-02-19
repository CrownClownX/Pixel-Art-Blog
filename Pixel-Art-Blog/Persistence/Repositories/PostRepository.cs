using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AutoMapper;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Core;

namespace Pixel_Art_Blog.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context)
            : base(context)
        {

        }

        public override Post Get(int id)
        {
            return BlogContext.Posts
                .Include(p => p.Category)
                .SingleOrDefault(p => p.ID == id);
        }

        public override IEnumerable<Post> GetAll()
        {
            return BlogContext.Posts
                .Include(p => p.Category)
                .ToList();
        }

        public BlogContext BlogContext
        {
            get { return Context as BlogContext; }
        }

        public IEnumerable<Post> GetPostsRange(int page, int size)
        {
            if (page <= 0)
                return new List<Post>();

            return BlogContext.Posts
                .Include(c => c.Category)
                .OrderBy(c => c.ID)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public QueryResult GetFiltrated(QueryInfo query)
        {
            var posts = query.IfIncluded 
                ? BlogContext.Posts.Include(c => c.Category)
                : BlogContext.Posts;

            if (query.CategoryId != null)
                posts = posts.Where(c => c.CategoryID == query.CategoryId);

            QueryResult result = new QueryResult()
            {
                CategoryId = query.CategoryId,
                CurrentPage = query.CurrentPage
            };

            result.TotalPages = (int)Math.Ceiling((decimal)posts.Count() / query.ItemsPerPage);

            result.Posts = posts.OrderByDescending(c => c.ID)
                .Skip((query.CurrentPage - 1) * query.ItemsPerPage)
                .Take(query.ItemsPerPage)
                .ToList();

            return result;
        }

        public override void Add(Post post)
        {
            if(post.ID == 0)
            {
                post.ReleaseDate = DateTime.Now;
                base.Add(post);

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