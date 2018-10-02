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

//TODO
//    implementation of Post if equal null
//    implementation of Index if number of posts is less than 6

namespace Pixel_Art_Blog.Controllers
{
    public class PostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private int _PageSize = 5;

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
            var post = _unitOfWork.Posts.Get(id);

            if (post == null)
            {
                throw new NotImplementedException();
            }

            var model = new PostViewModel()
            {
                Post = Mapper.Map<Post, PostDto>(post)
            };

            return View(model);
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult AllPosts(int page = 1, int categoryId = 0)
        {
            var posts = categoryId != 0
                ? _unitOfWork.Posts.GetPostsRangeWithCategory(page, _PageSize, categoryId)
                : _unitOfWork.Posts.GetPostsRange(page, _PageSize);

            var pageInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = _unitOfWork.Posts.GetAll().Count(),
                ItemsPerPage = _PageSize
            };

            var model = new AllPostsViewModel
            {
                Posts = posts.Select(Mapper.Map<Post, PostDto>).ToList(),
                Categories = _unitOfWork.Categories.GetAll()
                    .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                Info = pageInfo
            };

            return View(model);
        }
    }
}