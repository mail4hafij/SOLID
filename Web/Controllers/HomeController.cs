using API;
using API.Contracts;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IAnimalService svc = ServiceFactory.GetAnimalService();
            ViewBag.colorCat = svc.GetCat().Color;
            ViewBag.colorDog = svc.GetDog().Color;
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