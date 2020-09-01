[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RESTAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RESTAPI.App_Start.NinjectWebCommon), "Stop")]

namespace RESTAPI.App_Start
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Http;
    using API;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                
                
                // VERY IMPORTANT: ONLY FOR WEBAPI PROJECTS.
                // This following line is needed if we want to use ninject to construct the api controllers.
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);


                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Do all the bindings here.
            var connection = ConfigurationManager.AppSettings["AnimalServiceConnection"];
            kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalService(connection));
        }
    }
}