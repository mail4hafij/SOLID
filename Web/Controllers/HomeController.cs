using API;
using System.Web.Mvc;

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
            ViewBag.colorCat = _svc.GetCat(new API.Contracts.Cat.Messaging.GetCatReq()).Cat.Color;
            ViewBag.colorDog = _svc.GetDog(new API.Contracts.Dog.Messaging.GetDogReq()).Dog.Color;
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