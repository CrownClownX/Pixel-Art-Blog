using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Core.Repositories;
using Pixel_Art_Blog.Persistence.Repositories;
using Pixel_Art_Blog.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private List<Post> _Data
        {
            get
            {
                return new List<Post>
                {
                    new Post {ID = 1, Title = "P1", CategoryID = 2, ReleaseDate = DateTime.Now, Img = "Img1.jpg"},
                    new Post {ID = 2, Title = "P2", CategoryID = 3, ReleaseDate = DateTime.Now, Img = "Img2.jpg"},
                    new Post {ID = 3, Title = "P3", CategoryID = 1, ReleaseDate = DateTime.Now, Img = "Img3.jpg"},
                    new Post {ID = 4, Title = "P4", CategoryID = 2, ReleaseDate = DateTime.Now, Img = "Img4.jpg"},
                    new Post {ID = 5, Title = "P5", CategoryID = 3, ReleaseDate = DateTime.Now, Img = "Img5.jpg"},
                    new Post {ID = 6, Title = "P6", CategoryID = 1, ReleaseDate = DateTime.Now, Img = "Img.jpg"}
                };
            }
        }

        [TestMethod]
        public void GetAllTest()
        {
            var data = _Data.AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var post = repo.GetAll();

            Assert.IsNotNull(post);
            Assert.AreEqual(post.Count(), 6);
        }

        [TestMethod]
        public void GetAllNoRecordsTest()
        {
            IQueryable<Post> data = new List<Post>().AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var post = repo.GetAll();

            Assert.IsNotNull(post);
            Assert.AreEqual(post.Count(), 0);
        }

        [TestMethod]
        public void GetOneTest()
        {
            var data = _Data.AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var post = repo.Get(2);

            Assert.IsNotNull(post);
            Assert.AreEqual(post.ID, 2);
        }

        [TestMethod]
        public void GetOneWrongIdTest()
        {
            var data = _Data.AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var post = repo.Get(12);

            Assert.IsNull(post);
        }

        [TestMethod]
        public void FindTest()
        {
            var data = _Data.AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var posts = repo.Find(p => (p.ID > 2 && p.ID < 5));

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 2);
            Assert.AreEqual(posts.ToList()[0].ID, 3);
        }

        [TestMethod]
        public void FindWithNullTest()
        {
            var data = _Data.AsQueryable();

            IRepository<Post> repo = new Repository<Post>(
                MoqGenerator.DbContext_Mock(data).Object);

            var posts = repo.Find(null);

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 0);
        }
    }
}
