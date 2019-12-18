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
                BasicHttpBinding httpBinding = new BasicHttpBinding();
                NetTcpBinding tcpBinding = new NetTcpBinding();


                // EndPoint address hosted in IIS 
                // EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8733/WCFIIS/AnimalService");
                // EndPoint http address selfhosted
                // EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8734/WCF/AnimalService");
                // EndPoint tcp address selfhosted
                EndpointAddress endpointAddress = new EndpointAddress("net.tcp://localhost:8735/WCF/AnimalService");

                
                // Pass Binding and EndPoint address to ChannelFactory using httpBinding
                // channelFactory = new ChannelFactory<IAnimalService>(httpBinding, endpointAddress);
                // Pass Binding and EndPoint address to ChannelFactory using tcpBinding
                channelFactory = new ChannelFactory<IAnimalService>(tcpBinding, endpointAddress);


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

        public static IAnimalService GetAnimalService(string devURL = "http://localhost:54396/api")
        {
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                // Create a binding of the type exposed by service  
                BasicHttpBinding httpBinding = new BasicHttpBinding();
            
                // EndPoint address 
                EndpointAddress endpointAddress = new EndpointAddress(devURL);
                
                // Pass Binding and EndPoint address to ChannelFactory using httpBinding
                channelFactory = new ChannelFactory<IAnimalService>(httpBinding, endpointAddress);
                
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
