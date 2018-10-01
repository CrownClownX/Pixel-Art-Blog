using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class NewPostViewModel
    {
        public PostDto Post { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}