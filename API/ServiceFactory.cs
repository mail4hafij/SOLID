using System;
using System.ServiceModel;

namespace API
{
    public class ServiceFactory
    {
        public static IAnimalService GetAnimalServiceFromIIS()
        {
            // Create a ChannelFactory  
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                // Create a binding of the type exposed by service  
                BasicHttpBinding httpBinding = new BasicHttpBinding();
                // EndPoint address hosted in IIS 
                EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8733/WCFIIS/AnimalService");
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

        public static IAnimalService GetAnimalServiceFromWCF(bool tcp = true)
        {
            // Create a ChannelFactory  
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                if(tcp)
                {
                    // Create a binding of the type exposed by service  
                    NetTcpBinding tcpBinding = new NetTcpBinding();
                    // EndPoint tcp address selfhosted
                    EndpointAddress endpointAddressTcp = new EndpointAddress("net.tcp://localhost:8735/WCF/AnimalService");
                    // Pass Binding and EndPoint address to ChannelFactory using tcpBinding
                    channelFactory = new ChannelFactory<IAnimalService>(tcpBinding, endpointAddressTcp);

                }
                else
                {
                    // Create a binding of the type exposed by service  
                    BasicHttpBinding httpBinding = new BasicHttpBinding();
                    // EndPoint http address selfhosted
                    EndpointAddress endpointAddressHttp = new EndpointAddress("http://localhost:8734/WCF/AnimalService");
                    // Pass Binding and EndPoint address to ChannelFactory using httpBinding
                    channelFactory = new ChannelFactory<IAnimalService>(httpBinding, endpointAddressHttp);
                }

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

        public static IAnimalService GetAnimalServiceFromDev()
        {
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                // Create a binding of the type exposed by service  
                BasicHttpBinding httpBinding = new BasicHttpBinding();
                // EndPoint address 
                EndpointAddress endpointAddress = new EndpointAddress("http://localhost:54396/api");
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
