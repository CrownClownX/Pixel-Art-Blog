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
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
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

        private PostDto _newPost()
        {
            var post = new PostDto()
            {
                ID = 33,
                Title = "wew",
                Content = "aaaa",
                Description = "Adsad",
                CategoryID = 7,
                ReleaseDate = DateTime.Now
            };

            return post;
        }

        [TestMethod]
        public void AddNewPostTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object, 
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            FormViewModel model = new FormViewModel
            {
                Post = _newPost(),
                Img = MoqGenerator.Mock_HttpPostedFileBase().Object
            };

            controller.Save(model);

            Assert.AreEqual(data.Count(), 7);
            Assert.AreEqual(data[6].ID, 33);
        }

        [TestMethod]
        public void AddNewPostNullImgTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            FormViewModel model = new FormViewModel
            {
                Post = _newPost(),
                Img = null
            };

            var result = controller.Save(model);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var redirectedModel = viewResult.Model as NewPostViewModel;

            Assert.AreEqual(viewResult.ViewName, "PostForge");
            Assert.AreEqual(redirectedModel.Post.ID, 33);
        }

        [TestMethod]
        public void AddNewPostNullParameterTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.Save(null) as RedirectToRouteResult;

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            var redirectedResult = result as RedirectToRouteResult;

            Assert.AreEqual(redirectedResult.RouteValues["Action"], "NewPost");
        }

        [TestMethod]
        public void AdminPanelTest()
        {
            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(_dataPosts(), _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.AdminPanel();

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<PostDto>;

            Assert.AreEqual(_dataPosts().Count(), model.Count());
        }

        [TestMethod]
        public void NewPostTest()
        {
            var data = _dataCategories();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(_dataPosts(), data).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.NewPost();

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.Model as NewPostViewModel;

            Assert.AreEqual(data.Count(), model.Categories.Count());
        }

        [TestMethod]
        public void EditPostTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.EditPost(2);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;

            var model = viewResult.Model as NewPostViewModel;

            Assert.AreEqual(2, model.Post.ID);
        }

        [TestMethod]
        public void EditPostNoIdTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.EditPost();

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void EditPostWrongIdTest()
        {
            var data = _dataPosts();

            AdminController controller = new AdminController(
                MoqGenerator.GetMockRepository(data, _dataCategories()).Object,
                MoqGenerator.GetImageManager().Object,
                MoqGenerator.GetHttpContextServiec().Object);

            var result = controller.EditPost(322);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
