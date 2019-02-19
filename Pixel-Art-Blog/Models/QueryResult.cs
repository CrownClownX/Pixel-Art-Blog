using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class QueryResult
    {
        public int CurrentPage { get; set; }
        public int? CategoryId { get; set; }
        public List<Post> Posts { get; set; }
        public int TotalPages { get; set; }
    }
}