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
            if (posts.Count() != 0)
                MainPost = posts[0];
            else 
                MainPost = null;

            SidePosts = _setPosts(posts, 1, 2);
            RowPosts = _setPosts(posts, 3, 3);
            Categories = categories;
        }

        public PostDto MainPost { get; set; }
        public List<PostDto> SidePosts { get; set; }
        public List<PostDto> RowPosts { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public Subscriber Subscriber { get; set; }

        private List<PostDto> _setPosts(List<PostDto> posts, int start, int size)
        {
            if(posts.Count() < start)
            {
                return null;
            }

            if(posts.Count() < (start + size))
            {
                size = posts.Count() - start;
                //int differnce = posts.Count() - start;
                //List<PostDto> list = new List<PostDto>();

                //for (int i = start; i < (start + differnce); i++)
                //    list.Add(posts[i]);

                //return list;
            }

            return posts.GetRange(start, size);
        }
    }
}