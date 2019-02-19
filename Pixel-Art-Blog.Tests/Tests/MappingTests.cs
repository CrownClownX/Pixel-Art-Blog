using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.App_Start;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class MappingTests
    {
        private Category _newCategory()
        {
            var category = new Category
            {
                ID = 7,
                Description = "Some description",
                Name = "Cat7"
            };

            return category;
        }

        private CategoryDto _newCategoryDto()
        {
            var categoryDto = new CategoryDto
            {
                ID = 7,
                Description = "Some description",
                Name = "Cat7"
            };

            return categoryDto;
        }

        private PostDto _newPostDto()
        {
            var post = new PostDto()
            {
                ID = 33,
                Title = "wew",
                Content = "aaaa",
                Description = "Adsad",
                CategoryID = 7,
                ReleaseDate = DateTime.Now,
                Img = "Image",
                Category = _newCategoryDto()
            };

            return post;
        }

        private Post _newPost()
        {
            var post = new Post()
            {
                ID = 33,
                Title = "wew",
                Content = "aaaa",
                Description = "Adsad",
                CategoryID = 7,
                ReleaseDate = DateTime.Now,
                Img = "Image",
                Category = _newCategory()
            };

            return post;
        }

        private Subscriber _newSubscriber()
        {
            var subscriber = new Subscriber
            {
                ID = 7,
                Email = "email",
                Name = "Cat7"
            };

            return subscriber;
        }

        private SubscriberDto _newSubscriberDto()
        {
            var subscriberDto = new SubscriberDto
            {
                ID = 7,
                Email = "email",
                Name = "Cat7"
            };

            return subscriberDto;
        }

        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            MappingProfile.RegisterMap();
        }

        [TestMethod]
        public void PostToPostDtoTest()
        {
            var post = _newPost();

            var postDto = Mapper.Map<Post, PostDto>(post);

            Assert.AreEqual(post.ID, postDto.ID);
            Assert.AreEqual(post.Content, postDto.Content);
            Assert.AreEqual(post.Title, postDto.Title);
            Assert.AreEqual(post.Img, postDto.Img);
            Assert.AreEqual(post.ReleaseDate, postDto.ReleaseDate);
            Assert.AreEqual(post.Description, postDto.Description);
            Assert.AreEqual(post.CategoryID, postDto.CategoryID);

            Assert.AreEqual(post.Category.ID, postDto.Category.ID);
            Assert.AreEqual(post.Category.Name, postDto.Category.Name);
            Assert.AreEqual(post.Category.Description, postDto.Category.Description);
        }

        [TestMethod]
        public void PostDtoToPostTest()
        {
            var postDto = _newPostDto();

            var post = Mapper.Map<PostDto, Post>(postDto);

            Assert.AreEqual(post.ID, postDto.ID);
            Assert.AreEqual(post.Content, postDto.Content);
            Assert.AreEqual(post.Title, postDto.Title);
            Assert.AreEqual(post.Img, postDto.Img);
            Assert.AreEqual(post.ReleaseDate, postDto.ReleaseDate);
            Assert.AreEqual(post.Description, postDto.Description);
            Assert.AreEqual(post.CategoryID, postDto.CategoryID);

            Assert.AreEqual(post.Category.ID, postDto.Category.ID);
            Assert.AreEqual(post.Category.Name, postDto.Category.Name);
            Assert.AreEqual(post.Category.Description, postDto.Category.Description);
        }

        [TestMethod]
        public void CategoryToCategoryDto()
        {
            var category = _newCategory();

            var categoryDto = Mapper.Map<Category, CategoryDto>(category);

            Assert.AreEqual(category.ID, categoryDto.ID);
            Assert.AreEqual(category.Name, categoryDto.Name);
            Assert.AreEqual(category.Description, categoryDto.Description);
        }

        [TestMethod]
        public void CategoryDtoToCategoryDto()
        {
            var categoryDto = _newCategoryDto();

            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            Assert.AreEqual(category.ID, categoryDto.ID);
            Assert.AreEqual(category.Name, categoryDto.Name);
            Assert.AreEqual(category.Description, categoryDto.Description);
        }

        [TestMethod]
        public void SubscriberToSubscriberDto()
        {
            var subscriber = _newSubscriber();

            var subscriberDto = Mapper.Map<Subscriber, SubscriberDto>(subscriber);

            Assert.AreEqual(subscriber.ID, subscriberDto.ID);
            Assert.AreEqual(subscriber.Name, subscriberDto.Name);
            Assert.AreEqual(subscriber.Email, subscriberDto.Email);
        }

        [TestMethod]
        public void SubscriberDtoToSubscriber()
        {
            var subscriberDto = _newSubscriberDto();

            var subscriber = Mapper.Map<SubscriberDto, Subscriber>(subscriberDto);

            Assert.AreEqual(subscriber.ID, subscriberDto.ID);
            Assert.AreEqual(subscriber.Name, subscriberDto.Name);
            Assert.AreEqual(subscriber.Email, subscriberDto.Email);
        }
    }
}
