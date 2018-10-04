using Ninject;
using System;
using System.Reflection;
using System.ServiceModel;
using WCF.LIB;


namespace WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                /*
                // Option1: Using NijectModule. See the class Bindings
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                var handler = kernel.Get<IHandlerCaller>();
                */

                // Option2: Much preferable way I think.
                var container = new Container();
                var handler = container.Get<IHandlerCaller>();

                var animalService = new AnimalService(handler);
                svcHost = new ServiceHost(animalService);
                svcHost.Open();
                Console.WriteLine("\n\nService is Running");
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
            }
            if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}
