using AutoMapper;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixel_Art_Blog.App_Start
{
    public static class MappingProfile
    {
        public static void RegisterMap()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Post, PostDto>()
                    .ReverseMap();

                config.CreateMap<Category, CategoryDto>()
                    .ReverseMap();

                config.CreateMap<Subscriber, SubscriberDto>()
                    .ReverseMap();
            });
        }
    }
}