using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Models;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class PaginationTest
    {
        [TestMethod]
        public void CanPaginate()
        {
            PagingInfo info = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 6,
                ItemsPerPage = 3
            };

            Func<int, string> pageDelegate = i => "Page" + i;

            HtmlHelper myHelper = null;

            MvcHtmlString result = myHelper.PageLinks(info, pageDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>",
                result.ToString());
        }
    }
}
