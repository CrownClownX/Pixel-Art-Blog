using AutoMapper;
using Pixel_Art_Blog.Core;
using Pixel_Art_Blog.Core.Domain;
using Pixel_Art_Blog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pixel_Art_Blog.Controllers
{
    public class SubscribtionController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SubscribtionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Subscribtion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubscriber(SubscriberDto subscriberDto)
        {
            if (subscriberDto == null)
                return HttpNotFound();

            var subscriberDb = Mapper.Map<SubscriberDto, Subscriber>(subscriberDto);

            var subscriber = _unitOfWork.Subscribers.GetAll()
                .FirstOrDefault(e => e.Email == subscriberDto.Email);
            
            if (subscriber != null && !subscriber.Equals(default(Subscriber)))
                return View("AlreadyExist", subscriberDto);

            _unitOfWork.Subscribers.Add(subscriberDb);
            _unitOfWork.Complete();

            return View("AfterSignUp", subscriberDto);
        }
    }
}