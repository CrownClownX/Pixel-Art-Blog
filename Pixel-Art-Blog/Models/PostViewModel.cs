using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class PostViewModel
    {
        public PostDto Post { get; set; }
        public string Author { get { return "CrownClown"; }  }
    }
}