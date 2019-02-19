using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Core.Repositories;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Persistence;
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
    public class PostRepositoryTests
    {
        private List<Post> _Data
        {
            get
            {
                var categories = _dataCategories.ToList();

                return new List<Post>
                {
                    new Post {ID = 1, Title = "P1", CategoryID = 2, Category = categories[1], ReleaseDate = DateTime.Now, Img = "Img1.jpg"},
                    new Post {ID = 2, Title = "P2", CategoryID = 3, Category = categories[2], ReleaseDate = DateTime.Now, Img = "Img2.jpg"},
                    new Post {ID = 3, Title = "P3", CategoryID = 1, Category = categories[0], ReleaseDate = DateTime.Now, Img = "Img3.jpg"},
                    new Post {ID = 4, Title = "P4", CategoryID = 2, Category = categories[1], ReleaseDate = DateTime.Now, Img = "Img4.jpg"},
                    new Post {ID = 5, Title = "P5", CategoryID = 3, Category = categories[2], ReleaseDate = DateTime.Now, Img = "Img5.jpg"},
                    new Post {ID = 6, Title = "P6", CategoryID = 1, Category = categories[0], ReleaseDate = DateTime.Now, Img = "Img.jpg"}
                };
            }
        }

        private List<Category> _dataCategories
        {
            get
            {
                var data = new List<Category>()
                {
                    new Category {ID = 1, Name = "C1" },
                    new Category {ID = 2, Name = "C2" },
                    new Category {ID = 3, Name = "C3" }
                };

                return data;
            }
        }

        [TestMethod]
        public void GetRangeTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetPostsRange(1, 5);

            Assert.IsNotNull(posts);
            Assert.IsNotNull(posts.ToList()[0].Category);
            Assert.AreEqual(posts.Count(), 5);
            Assert.AreEqual(posts.ToList()[1].ID, 2);
        }

        [TestMethod]
        public void GetRangeOutOfRangeTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetPostsRange(7, 3);

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 0);
        }

        [TestMethod]
        public void GetRangePartlyInRangeTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetPostsRange(2, 4);

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 2);
        }

        [TestMethod]
        public void GetRangePageZeroTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetPostsRange(0, 4);

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 0);
        }

        [TestMethod]
        public void GetRangeSizeZeroTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetPostsRange(1, 0);

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 0);
        }

        [TestMethod]
        public void GetOneTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var post = repo.Get(1);

            Assert.IsNotNull(post);
            Assert.AreEqual(post.ID, 1);
            Assert.IsNotNull(post.Category);
        }

        [TestMethod]
        public void GetOneWrongIDTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var post = repo.Get(11);

            Assert.IsNull(post);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetAll();

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 6);
            Assert.IsNotNull(posts.ToList()[0].Category);
        }

        [TestMethod]
        public void GetAllNoRecordsTest()
        {
            var data = (new List<Post>()).AsQueryable();
            var dataCat = (new List<Category>()).AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var posts = repo.GetAll();

            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count(), 0);
        }

        [TestMethod]
        public void GetFiltratedTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var query = new QueryInfo
            {
                ItemsPerPage = 2,
                CurrentPage = 1,
                CategoryId = 1,
                IfIncluded = true
            };

            var result = repo.GetFiltrated(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalPages, 1);
            Assert.AreEqual(result.Posts.Count(), 2);
        }

        [TestMethod]
        public void GetFiltratedNullCategoryTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var query = new QueryInfo
            {
                ItemsPerPage = 2,
                CurrentPage = 1,
                CategoryId = null,
                IfIncluded = true
            };

            var result = repo.GetFiltrated(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalPages, 3);
            Assert.AreEqual(result.Posts.Count(), 2);
        }

        [TestMethod]
        public void GetFiltratedNonExsistingCategoryTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var query = new QueryInfo
            {
                ItemsPerPage = 2,
                CurrentPage = 1,
                CategoryId = 5,
                IfIncluded = true
            };

            var result = repo.GetFiltrated(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalPages, 0);
            Assert.AreEqual(result.Posts.Count(), 0);
        }

        [TestMethod]
        public void GetFiltratedNonExsistingPageTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var query = new QueryInfo
            {
                ItemsPerPage = 2,
                CurrentPage = 11,
                CategoryId = 5,
                IfIncluded = true
            };

            var result = repo.GetFiltrated(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalPages, 0);
            Assert.AreEqual(result.Posts.Count(), 0);
        }

        public void GetFiltratedNotFullPageTest()
        {
            var data = _Data.AsQueryable();
            var dataCat = _dataCategories.AsQueryable();

            IPostRepository repo = new PostRepository(
                MoqGenerator.BlogContext_Mock(data, dataCat).Object);

            var query = new QueryInfo
            {
                ItemsPerPage = 4,
                CurrentPage = 2,
                CategoryId = null,
                IfIncluded = true
            };

            var result = repo.GetFiltrated(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalPages, 2);
            Assert.AreEqual(result.Posts.Count(), 2);
        }

    }
}
