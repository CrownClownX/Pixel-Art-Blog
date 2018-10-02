using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class FormViewModel
    {
        public PostDto Post { get; set; }
        public HttpPostedFileBase Img { get; set; }
    }
}