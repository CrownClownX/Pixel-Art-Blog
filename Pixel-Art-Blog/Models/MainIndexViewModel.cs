using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Models
{
    public class MainIndexViewModel
    {
        public MainIndexViewModel(List<PostDto> posts, List<CategoryDto> categories)
        {
            if (posts.Count < 6)
            {
                throw new NotImplementedException();
            }

            MainPost = posts[0] ?? new PostDto();
            SidePosts = posts.GetRange(1, 2) ?? new List<PostDto>(); 
            RowPosts = posts.GetRange(3, 3) ?? new List<PostDto>(); 
            Categories = categories;
        }

        public PostDto MainPost { get; set; }
        public List<PostDto> SidePosts { get; set; }
        public List<PostDto> RowPosts { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}