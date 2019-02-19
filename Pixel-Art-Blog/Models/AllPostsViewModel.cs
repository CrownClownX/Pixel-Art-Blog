using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class AllPostsViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public QueryResult Result { get; set; }
    }
}