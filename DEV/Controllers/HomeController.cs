﻿using API;
using System;
using System.Web.Mvc;

namespace DEV.Controllers
{
    public class HomeController : Controller
    {
        private IAnimalService _svc;

        // Constructor injection. Checkout NinjectWebCommon class.
        public HomeController(IAnimalService svc)
        {
            _svc = svc;
        }

        public ActionResult Index()
        {
            var respCat = _svc.GetCat(new API.Contracts.Cat.Messaging.GetCatReq());
            if (respCat.Success != true && respCat.ExceptionError != null && respCat.ExceptionError.StackTrace != null)
            {
                throw new Exception(respCat.ExceptionError.StackTrace);
            }

            var respDog = _svc.GetDog(new API.Contracts.Dog.Messaging.GetDogReq());
            if (respDog.Success != true && respDog.ExceptionError != null && respDog.ExceptionError.StackTrace != null)
            {
                throw new Exception(respDog.ExceptionError.StackTrace);
            }

            ViewBag.colorCat = respCat.Cat.Color;
            ViewBag.colorDog = respDog.Dog.Color;
                        
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}