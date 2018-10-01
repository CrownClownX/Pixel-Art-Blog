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

        public ViewResult PostForge(int id = 0)
        {
            var model = new NewPostViewModel()
            {
                Categories = _unitOfWork.Categories.GetAll()
                      .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                Post = new PostDto()
                {
                    ID = 1
                }
            };

            if (id == 0)
            {
                return View(model);
            }

            var post = _unitOfWork.Posts.Get(id);
            model.Post = Mapper.Map<Post, PostDto>(post);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PostDto post)
        {
            if(!ModelState.IsValid)
            {
                var model = new NewPostViewModel()
                {
                    Categories = _unitOfWork.Categories.GetAll()
                      .Select(Mapper.Map<Category, CategoryDto>).ToList(),
                    Post = post
                };

                return View("PostForge", model);
            }

            if(post.ID == 0)
            {
                post.ReleaseDate = DateTime.Now;
                _unitOfWork.Posts.Add(Mapper.Map<PostDto, Post>(post));
            }

            _unitOfWork.Posts.Update(Mapper.Map<PostDto, Post>(post));
            _unitOfWork.Save();

            return RedirectToAction("Index", "Post");
        }
    }
}