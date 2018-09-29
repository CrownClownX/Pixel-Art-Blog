using Moq;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Tests.Helpers
{
    public static class MoqGenerator
    {
        private static IEnumerable<Post> _dataPosts()
        {
            var data = new List<Post>()
            {
                new Post {ID = 1, Title = "P1", CategoryID = 2, ReleaseDate = DateTime.Now},
                new Post {ID = 2, Title = "P2", CategoryID = 3, ReleaseDate = DateTime.Now},
                new Post {ID = 3, Title = "P3", CategoryID = 1, ReleaseDate = DateTime.Now},
                new Post {ID = 4, Title = "P4", CategoryID = 2, ReleaseDate = DateTime.Now},
                new Post {ID = 5, Title = "P5", CategoryID = 3, ReleaseDate = DateTime.Now},
                new Post {ID = 6, Title = "P6", CategoryID = 1, ReleaseDate = DateTime.Now}
            };

            return data;
        }

        private static IEnumerable<Category> _dataCategories()
        {
            var data = new List<Category>()
            {
                new Category {ID = 1, Name = "C1" },
                new Category {ID = 2, Name = "C2" },
                new Category {ID = 3, Name = "C3" }
            };

            return data;
        }

        public static Mock<IUnitOfWork> GetMock()
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            mock.Setup(m => m.Posts.GetPostsRange(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int page, int size) => _dataPosts()
                    .OrderBy(d => d.ID)
                    .Skip((page - 1) * size)
                    .Take(size));

            mock.Setup(m => m.Categories.GetAll())
                .Returns(() => _dataCategories());

            mock.Setup(m => m.Posts.Get(It.IsAny<int>()))
                .Returns((int id) => _dataPosts()
                    .SingleOrDefault(p => p.ID == id));

            return mock;
        }
    }
}
