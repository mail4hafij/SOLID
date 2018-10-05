using System.ServiceModel.Activation;
using System.Web.Mvc;
using System.Web.Routing;
using WCF;

namespace DEV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Binding AnimalService from WCF project directly wihthout the need for WCF host.
            routes.Add(new ServiceRoute("api", new Ninject.Extensions.Wcf.NinjectServiceHostFactory(), typeof(AnimalService))
            {
                Constraints = new RouteValueDictionary(new { controller = string.Empty, action = string.Empty })
            });
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
