using FluentValidation;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.Persistence.Configurations
{
    public class PostDtoValidator : AbstractValidator<PostDto>
    {
        public PostDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .Length(1, 50);

            RuleFor(p => p.Description)
                .NotEmpty()
                .Length(1, 500);

            RuleFor(p => p.Content)
                .NotEmpty();

            RuleFor(p => p.CategoryID)
                .NotEmpty();
        }
    }
}