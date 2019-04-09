using AutoMapper;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Helpers.Interfaces;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IImageManager _imageManager;
        private readonly IHttpContextService _contextService;
        private readonly string _path = "~/Content/Img/";

        public AdminController(IUnitOfWork unitOfWork, IImageManager imageManager, IHttpContextService contextService)
        {
            _unitOfWork = unitOfWork;
            _imageManager = imageManager;
            _contextService = contextService;

            if (!Directory.Exists(_contextService.GetMapPath(_path)))
            {
                Directory.CreateDirectory(_contextService.GetMapPath(_path));
            }
        }

        // GET: Admin
        public ViewResult AdminPanel()
        {
            var model = _unitOfWork.Posts.GetAll()
                .Select(Mapper.Map<Post, PostDto>).ToList();

            return View(model);
        }

        public ViewResult NewPost()
        {
            var model = new NewPostViewModel()
            {
                Categories = _unitOfWork.Categories.GetAll()
                     .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                Post = new PostDto()
            };

            return View("PostForge", model);
        }

        public ActionResult EditPost(int id = 0)
        {
            var post = _unitOfWork.Posts.Get(id);

            if (post == null)
                return HttpNotFound();

            var model = new NewPostViewModel()
            {
                Categories = _unitOfWork.Categories.GetAll()
                      .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                Post = Mapper.Map<Post, PostDto>(post),
            };

            return View("PostForge", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormViewModel formData)
        {
            if(formData == null)
                return RedirectToAction("NewPost");

            var model = new NewPostViewModel()
            {
                 Categories = _unitOfWork.Categories.GetAll()
                     .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                 Post = formData.Post,
                 Img = formData.Img
            };

            if (!ModelState.IsValid)
                return View("PostForge", model);

            formData.Post.Img = _imageManager.SaveImage(formData.Img, 
                _contextService.GetMapPath(_path));

            if(formData.Post.Img == null)
                return View("PostForge", model);

            _unitOfWork.Posts.Add(Mapper.Map<PostDto, Post>(formData.Post));
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Post");
        }
    }
}