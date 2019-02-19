using FluentValidation.Attributes;
using Pixel_Art_Blog.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Core.Domain
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public DateTime ReleaseDate { get; set; }
        public String Img { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}