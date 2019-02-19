using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pixel_Art_Blog.Controllers;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using Pixel_Art_Blog.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Tests.Tests
{
    [TestClass]
    public class SubscribtionControllerTests
    {
        private static List<Subscriber> _dataSubscribers()
        {
            var data = new List<Subscriber>
            {
                new Subscriber { ID = 1, Name = "Sub1", Email = "email1@sd.com"},
                new Subscriber { ID = 2, Name = "Sub2", Email = "email2@sd.com"},
                new Subscriber { ID = 3, Name = "Sub3", Email = "email3@sd.com"},
            };

            return data;
        }

        private SubscriberDto _NewSubscriberDto()
        {
            return new SubscriberDto
            {
                ID = 4,
                Name = "Sub4",
                Email = "email4@sd.com"
            };
        }

        [TestMethod]
        public void AddSubscriberTest()
        {
            var data = _dataSubscribers();

            SubscribtionController controller = new SubscribtionController(
                MoqGenerator.GetMockRepositorySub(data).Object);

            var subscriberDto = _NewSubscriberDto();

            controller.AddSubscriber(subscriberDto);

            Assert.AreEqual(data.Count(), 4);
            Assert.AreEqual(data[3].ID, 4);
        }

        [TestMethod]
        public void AddSubscriberNullTest()
        {
            SubscribtionController controller = new SubscribtionController(
                MoqGenerator.GetMockRepositorySub(_dataSubscribers()).Object);

            var result = controller.AddSubscriber(null);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void AddSubscriberAlreadyExistTest()
        {
            SubscribtionController controller = new SubscribtionController(
                MoqGenerator.GetMockRepositorySub(_dataSubscribers()).Object);

            var subscriberDto = new SubscriberDto
            {
                ID = 2,
                Name = "Sub2",
                Email = "email2@sd.com"
            };

            var result = controller.AddSubscriber(subscriberDto);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;

            Assert.AreEqual(viewResult.ViewName, "AlreadyExist");
        }
    }
}
