using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAPI.Controllers
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
            ViewBag.colorCat = _svc.GetCat(new API.Contracts.Cat.Messaging.GetCatReq()).Cat.Color;
            ViewBag.colorDog = _svc.GetDog(new API.Contracts.Dog.Messaging.GetDogReq()).Dog.Color;
            ViewBag.colorTiger = _svc.GetTiger(new API.Contracts.Tiger.Messaging.GetTigerReq()).Tiger.Color;
            return View();
        }
    }
}
