using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Controllers;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void AddNewPostTest()
        {
            AdminController controller = 
                new AdminController(MoqGenerator.GetMockRepository().Object);

            var post = new PostDto()
            {
                ID = 33,
                Title = "wew",
                Content = "aaaa",
                Description = "Adsad",
            };


        }
    }
}
