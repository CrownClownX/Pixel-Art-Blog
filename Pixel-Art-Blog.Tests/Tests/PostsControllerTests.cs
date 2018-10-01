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

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class PostsControllerTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
             MappingProfile.RegisterMap();
        }

        [TestMethod]
        public void MainIndexViewModelTest()
        {
            PostController controller = 
                new PostController(MoqGenerator.GetMock().Object);

            var result = controller.Index().Model as MainIndexViewModel;

            Assert.AreEqual(result.MainPost.ID, 1);
            Assert.IsTrue(result.SidePosts.Count == 2);
            Assert.IsTrue(result.RowPosts.Count == 3);
            Assert.AreEqual(result.SidePosts[0].Title, "P2");
            Assert.AreEqual(result.RowPosts[2].Title, "P6");
        }

        [TestMethod]
        public void GetRightPostTest()
        {
            PostController controller =
                new PostController(MoqGenerator.GetMock().Object);

            var result = controller.Post(3).Model as PostDto;

            Assert.AreEqual(result.ID, 3);
            Assert.IsTrue(result.Title == "P3");
        }
    }
}
