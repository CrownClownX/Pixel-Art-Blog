using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsRange(int page, int size);
        IEnumerable<Post> GetPostsRangeWithCategory(int page, int size, int categoryId);
        void Save(Post post);
    }
}
