using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.App_Start;
using Pixel_Art_Blog.Controllers;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class PostsControllerTests 
    {
        public TestContext TestContext { get; set; }

        private List<Post> _dataPosts()
        {
            var data = new List<Post>()
            {
                new Post {ID = 1, Title = "P1", CategoryID = 2, ReleaseDate = DateTime.Now, Img = "Img1.jpg"},
                new Post {ID = 2, Title = "P2", CategoryID = 3, ReleaseDate = DateTime.Now, Img = "Img2.jpg"},
                new Post {ID = 3, Title = "P3", CategoryID = 1, ReleaseDate = DateTime.Now, Img = "Img3.jpg"},
                new Post {ID = 4, Title = "P4", CategoryID = 2, ReleaseDate = DateTime.Now, Img = "Img4.jpg"},
                new Post {ID = 5, Title = "P5", CategoryID = 3, ReleaseDate = DateTime.Now, Img = "Img5.jpg"},
                new Post {ID = 6, Title = "P6", CategoryID = 1, ReleaseDate = DateTime.Now, Img = "Img.jpg"}
            };

            return data;
        }

        private List<Category> _dataCategories()
        {
            var data = new List<Category>()
            {
                new Category {ID = 1, Name = "C1" },
                new Category {ID = 2, Name = "C2" },
                new Category {ID = 3, Name = "C3" }
            };

            return data;
        }

        [TestMethod]
        public void MainIndexViewModelTest()
        {
            PostController controller = 
                new PostController(MoqGenerator.GetMockRepository(
                    _dataPosts(), _dataCategories()).Object);

            var result = controller.Index().Model as MainIndexViewModel;

            Assert.AreEqual(result.MainPost.ID, 1);
            Assert.IsTrue(result.SidePosts.Count == 2);
            Assert.IsTrue(result.RowPosts.Count == 3);
            Assert.AreEqual(result.SidePosts[0].Title, "P2");
            Assert.AreEqual(result.RowPosts[2].Title, "P6");
        }

        [TestMethod]
        public void GetPostTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMockRepository(_dataPosts(), 
                _dataCategories()).Object);

            var result = controller.Post(3);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model as PostViewModel;

            Assert.IsTrue(model != null);
            Assert.IsTrue(model.Post != null);

            Assert.AreEqual(model.Post.ID, 3);
            Assert.IsTrue(model.Post.Title == "P3");
        }

        [TestMethod]
        public void GetPostWrongIdTest()
        {
            PostController controller =
            new PostController(MoqGenerator.GetMockRepository(_dataPosts(),
            _dataCategories()).Object);

            var result = controller.Post(13);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void AllPostsOnlyPageNumberTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMockRepository(_dataPosts(),
                _dataCategories()).Object);

            var result = controller.AllPosts(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model;

            Assert.IsInstanceOfType(model, typeof(AllPostsViewModel));

            var allPostViewModel = model as AllPostsViewModel;

            Assert.AreEqual(5, allPostViewModel.Result.Posts.Count());
        }

        [TestMethod]
        public void AllPostsDefaultPageNumberTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMockRepository(_dataPosts(),
                _dataCategories()).Object);

            var result = controller.AllPosts();

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model;

            Assert.IsInstanceOfType(model, typeof(AllPostsViewModel));

            var allPostViewModel = model as AllPostsViewModel;

            Assert.AreEqual(5, allPostViewModel.Result.Posts.Count());
        }

        [TestMethod]
        public void AllPostsPageNumberAndCategoryTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMockRepository(_dataPosts(),
                _dataCategories()).Object);

            var result = controller.AllPosts(1, 2);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model;

            Assert.IsInstanceOfType(model, typeof(AllPostsViewModel));

            var allPostViewModel = model as AllPostsViewModel;

            foreach(var post in allPostViewModel.Result.Posts)
                Assert.AreEqual(2, post.CategoryID);
        }

        [TestMethod]
        public void AllPostsNonExsistingPageTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMockRepository(_dataPosts(),
                _dataCategories()).Object);

            var result = controller.AllPosts(11);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
