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

            MainIndexViewModel model = new MainIndexViewModel(posts, categories)
            {
                Subscriber = new Subscriber()
            };

            return View(model);
        }

        public ActionResult AllPosts(int page = 1, int? categoryId = null)
        {
            var query = new QueryInfo()
            {
                ItemsPerPage = _PageSize,
                CategoryId = categoryId,
                CurrentPage = page,
                IfIncluded = true
            };

            var result = _unitOfWork.Posts.GetFiltrated(query);

            var model = new AllPostsViewModel
            {
                Categories = _unitOfWork.Categories.GetAll()
                    .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                Result = result
            };

            return View(model);
        }

        public ActionResult Post(int id)
        {
            var post = _unitOfWork.Posts.Get(id);

            if (post == null)
                return HttpNotFound();

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
    }
}