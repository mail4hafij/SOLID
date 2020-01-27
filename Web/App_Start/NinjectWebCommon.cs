using API;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Configuration;
using System.Web;
using WEB.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace WEB.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper _bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            _bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            _bootstrapper.ShutDown();
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

            // Option 1: We can connect to a Service using ServiceFactory that is hosted in IIS.
            // kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromIIS());

            // Option 2: We can connect to a Service using ServiceFactory that is self hosted by WCF (tcp).
            // kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromWCF(true));

            // Option 3: We can connect to a Service using ServiceFactory that is self hosted by WCF (http).
            // kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromWCF(false));

            // Option 4: We can connect to a Service using ServiceFactory that is not hosted but uses the DEV web project.
            // The DEV web project connects internally to SRC project.
            // kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromDev());

            var connection = ConfigurationManager.AppSettings["AnimalServiceConnection"];
            switch(connection)
            {
                case "dev":
                    // Option 4: We can connect to a Service using ServiceFactory that is not hosted but uses the DEV web project.
                    // The DEV web project connects internally to SRC project.
                    kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromDev());
                    break;
                case "wcf":
                    // Option 2: We can connect to a Service using ServiceFactory that is self hosted by WCF (tcp).
                    kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromWCF(true));
                    break;
                default:
                    // Option 4: We can connect to a Service using ServiceFactory that is not hosted but uses the DEV web project.
                    // The DEV web project connects internally to SRC project.
                    kernel.Bind<IAnimalService>().ToMethod(svc => ServiceFactory.GetAnimalServiceFromDev());
                    break;
            }

        }
    }
}