using System;
using System.ServiceModel;

namespace API
{
    public class ServiceFactory
    {
        public static IAnimalService GetAnimalService()
        {
            // Create a ChannelFactory  
            // Required Namespace: using System.ServiceModel;  
            // Required Namespace: using ServiceLibrary;  
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                // Create a binding of the type exposed by service  
                BasicHttpBinding binding = new BasicHttpBinding();

                // EndPoint address hosted in IIS 
                // EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8733/SRC/AnimalService");
                // EndPoint address selfhosted
                EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8734/SRC/AnimalService");


                // Pass Binding and EndPoint address to ChannelFactory  
                channelFactory = new ChannelFactory<IAnimalService>(binding, endpointAddress);

                // Now create the new channel as below  
                IAnimalService channel = channelFactory.CreateChannel();

                return channel;
            }
            catch (TimeoutException)
            {
                // Timeout error  
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (FaultException)
            {
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (CommunicationException)
            {
                // Communication error  
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (Exception)
            {
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
        }
    }
}
