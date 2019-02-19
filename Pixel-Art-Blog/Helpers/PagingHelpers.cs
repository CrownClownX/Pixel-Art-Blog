using Pixel_Art_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, 
            int totalPages, int currentPage, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for(int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                
                if(currentPage == i)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-first");
                }

                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}