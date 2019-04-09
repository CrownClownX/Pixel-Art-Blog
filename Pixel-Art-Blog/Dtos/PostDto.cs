using FluentValidation.Attributes;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Dtos
{
    public class PostDto
    {
        public PostDto()
        {
            Title = "";
            Description = "";
            Content = "";
            Category = new CategoryDto();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Img { get; set; }

        public CategoryDto Category { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
    }
}