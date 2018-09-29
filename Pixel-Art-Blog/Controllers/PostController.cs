using AutoMapper;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Controllers
{
    public class PostController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index()
        {
            var posts = _unitOfWork.Posts.GetPostsRange(1, 6).ToList()
                .Select(Mapper.Map<Post, PostDto>).ToList();

            var categories = _unitOfWork.Categories.GetAll().ToList()
                    .Select(Mapper.Map<Category, CategoryDto>).ToList();

            MainIndexViewModel model = new MainIndexViewModel(posts, categories);

            return View(model);
        }

        public ViewResult Post(int id)
        {
            var model = _unitOfWork.Posts.Get(id);

            if(model == null)
            {
                throw new NotImplementedException();
            }

            return View(Mapper.Map<Post, PostDto>(model));
        }
    }
}