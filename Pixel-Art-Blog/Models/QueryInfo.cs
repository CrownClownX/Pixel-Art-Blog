using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class QueryInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int? CategoryId { get; set; }
        public bool IfIncluded { get; set; }
    }
}