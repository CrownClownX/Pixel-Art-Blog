using AutoMapper;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Helpers;
using Pixel_Art_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//TODO
//Don't know how send image with Edit action. So it's still not implemented (here and in Repository)

namespace Pixel_Art_Blog.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            if(id == 0)
            {
                return HttpNotFound();
            }

            var post = _unitOfWork.Posts.Get(id);

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
            if (!ModelState.IsValid)
            {
                var model = new NewPostViewModel()
                {
                    Categories = _unitOfWork.Categories.GetAll()
                      .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                    Post = formData.Post,
                    Img = formData.Img
                };

                return View("PostForge", model);
            }

            formData.Post.Img = ImageManager.GetImagePath(formData.Img,
                _unitOfWork, HttpContext.Server.MapPath("~/Content/Img/")) ?? formData.Post.Img;
           
            _unitOfWork.Posts.Save(Mapper.Map<PostDto, Post>(formData.Post));
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Post");
        }
    }
}