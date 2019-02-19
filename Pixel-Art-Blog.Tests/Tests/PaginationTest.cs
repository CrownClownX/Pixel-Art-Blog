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
            int totalPages = 2;
            int currentPage = 2;

            Func<int, string> pageDelegate = i => "Page" + i;

            HtmlHelper myHelper = null;

            MvcHtmlString result = myHelper.PageLinks(totalPages, currentPage, pageDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-first selected"" href=""Page2"">2</a>",
                result.ToString());
        }
    }
}
