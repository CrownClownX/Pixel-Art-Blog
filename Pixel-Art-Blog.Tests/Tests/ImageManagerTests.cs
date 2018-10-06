using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class ImageManagerTests
    {
        [TestMethod]
        public void ImagePathIsGenerated()
        {
            var result = ImageManager.GetImagePath(MoqGenerator.GetMockHttpPostedFileBase().Object,
                MoqGenerator.GetMockRepository().Object, "~/Content/Img/");
            var result2 = ImageManager.GetImagePath(MoqGenerator.GetMockHttpPostedFileBase().Object,
                MoqGenerator.GetMockRepository().Object, "~/Content/Img/");

            Assert.AreEqual("Img6.jpg", result);
        }
    }
}
