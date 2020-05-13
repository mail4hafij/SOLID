using API;
using System;
using System.Web.Mvc;
using WEB.Models.Animal;

namespace WEB.Controllers
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
            var respDog = _svc.GetDog(new API.Contracts.Dog.Messaging.GetDogReq());
            var respTiger = _svc.GetTiger(new API.Contracts.Tiger.Messaging.GetTigerReq());
            
            ViewBag.colorCat = respCat.Cat.Color;
            ViewBag.colorDog = respDog.Dog.Color;
            ViewBag.colorTiger = respTiger.Tiger.Color;

            return View();
        }

        [HttpPost]
        public ActionResult AddAnimal(AddAnimalPostback data)
        {
            var catColor = data.Form.CatColor;
            var dogColor = data.Form.DogColor;
            
            _svc.AddAnimals(new API.Contracts.Animals.Messaging.AddAnimalsReq() {
                CatColor = catColor, DogColor = dogColor
            });

            return RedirectToAction("Index");
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