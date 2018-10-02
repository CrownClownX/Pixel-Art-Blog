using Pixel_Art_Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Dtos
{
    public class PostDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Img { get; set; }

        public CategoryDto Category { get; set; }
        public int CategoryID { get; set; }
    }
}