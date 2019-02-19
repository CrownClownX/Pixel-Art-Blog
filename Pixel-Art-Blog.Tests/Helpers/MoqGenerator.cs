using Moq;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Helpers.Interfaces;
using Pixel_Art_Blog.Models;
using Pixel_Art_Blog.Persistence;
using Pixel_Art_Blog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pixel_Art_Blog.Tests.Helpers
{
    public static class MoqGenerator
    {
        public static Mock<IUnitOfWork> GetMockRepository(List<Post> _dataPosts, List<Category> _dataCategories)
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            mock.Setup(m => m.Posts.GetPostsRange(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int page, int size) => _dataPosts
                    .OrderBy(d => d.ID)
                    .Skip((page - 1) * size)
                    .Take(size));

            mock.Setup(m => m.Posts.GetFiltrated(It.IsAny<QueryInfo>()))
                .Returns((QueryInfo query) =>
                {
                    QueryResult queryResult = new QueryResult
                    {
                        CurrentPage = query.CurrentPage,
                        CategoryId = query.CategoryId
                    };

                    var result = query.CategoryId != null
                        ? _dataPosts.Where(p => p.CategoryID == query.CategoryId)
                        : _dataPosts;

                    queryResult.Posts = result.Skip(query.ItemsPerPage * (query.CurrentPage - 1))
                        .Take(query.ItemsPerPage).ToList();

                    return queryResult;
                });

            mock.Setup(m => m.Categories.GetAll())
                .Returns(() => _dataCategories);

            mock.Setup(m => m.Posts.GetAll())
                .Returns(() => _dataPosts);

            mock.Setup(m => m.Posts.Get(It.IsAny<int>()))
                .Returns((int id) => _dataPosts
                    .SingleOrDefault(p => p.ID == id));

            mock.Setup(m => m.Posts.Find(It.IsAny<Expression<Func<Post, bool>>>()))
                .Returns((Expression<Func<Post, bool>> predicate) =>
                    _dataPosts.AsQueryable().Where(predicate));

            mock.Setup(m => m.Posts.Add(It.IsAny<Post>()))
                .Callback((Post entity) => _dataPosts.Add(entity))
                .Verifiable();

            mock.Setup(m => m.Complete())
                .Verifiable();

            return mock;
        }

        public static Mock<IUnitOfWork> GetMockRepositorySub(List<Subscriber> _dataSubscribers)
        {
            Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();

            mock.Setup(m => m.Subscribers.GetAll())
                .Returns(() => _dataSubscribers);

            mock.Setup(m => m.Subscribers.Add(It.IsAny<Subscriber>()))
                .Callback((Subscriber entity) => _dataSubscribers.Add(entity))
                .Verifiable();

            mock.Setup(m => m.Complete())
                .Verifiable();

            return mock;
        }

        public static Mock<IImageManager> GetImageManager()
        {
            Mock<IImageManager> mock = new Mock<IImageManager>();

            mock.Setup(m => m.SaveImage(It.IsAny<HttpPostedFileBase>(), It.IsAny<string>()))
                .Returns((HttpPostedFileBase img, string path) => (img != null)
                ? "Image" : null);

            return mock;
        }

        public static Mock<IHttpContextService> GetHttpContextServiec()
        {
            Mock<IHttpContextService> mock = new Mock<IHttpContextService>();

            mock.Setup(m => m.GetMapPath(It.IsAny<string>()))
                .Returns((string path) => path);

            return mock;
        }

        public static Mock<DbSet<T>> DbSet_Mock<T>(IQueryable<T> _data, bool ifFind = false) where T : class
        {
            var data = _data;
            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Provider).Returns(data.Provider);
            dbSet.As<IQueryable<T>>()
                .Setup(m => m.Expression).Returns(data.Expression);
            dbSet.As<IQueryable<T>>()
                .Setup(m => m.ElementType).Returns(data.ElementType);
            dbSet.As<IQueryable<T>>()
                .Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            dbSet.Setup(m => m.Include(It.IsAny<String>())).Returns(dbSet.Object);

            if (ifFind)
            {
                dbSet.Setup(d => d.Find(It.IsAny<object[]>()))
                    .Returns<object[]>(x => (data as IQueryable<Post>)
                        .FirstOrDefault(p => p.ID == (int)x[0]) as T);
            }

            return dbSet;
        }

        public static Mock<DbContext> DbContext_Mock<T>(IQueryable<T> _data) where T : class
        {
            Mock<DbContext> mock = new Mock<DbContext>();

            mock.Setup(m => m.Set<T>()).Returns(DbSet_Mock(_data, true).Object);

            return mock;
        }

        public static Mock<BlogContext> BlogContext_Mock(IQueryable<Post> _data, IQueryable<Category> _dataCat) 
        {
            Mock<BlogContext> mock = new Mock<BlogContext>();

            mock.Setup(m => m.Posts)
                .Returns(DbSet_Mock(_data).Object);

            mock.Setup(m => m.Categories)
                .Returns(DbSet_Mock(_dataCat).Object);

            return mock;
        }

        public static Mock<HttpPostedFileBase> Mock_HttpPostedFileBase()
        {
            Mock<HttpPostedFileBase> mock = new Mock<HttpPostedFileBase>();

            return mock;        }
    }
}
