using System;
using System.ServiceModel;

namespace API
{
    public class ServiceFactory
    {
        public static IAnimalService GetAnimalService(string connection)
        {
            ChannelFactory<IAnimalService> channelFactory = null;

            try
            {
                if(connection.StartsWith("net.tcp"))
                {
                    // TODO: some security credential can be added
                    // Create a binding of the type exposed by service  
                    NetTcpBinding tcpBinding = new NetTcpBinding();
                    // EndPoint tcp address selfhosted
                    EndpointAddress endpointAddressTcp = new EndpointAddress(connection);
                    // Pass Binding and EndPoint address to ChannelFactory using tcpBinding
                    channelFactory = new ChannelFactory<IAnimalService>(tcpBinding, endpointAddressTcp);
                    // Now create the new channel as below
                    IAnimalService channel = channelFactory.CreateChannel();
                    return channel;
                }
                else if (connection.StartsWith("https"))
                {
                    // HTTPS
                    // Create a binding of the type exposed by service  
                    BasicHttpsBinding httpsBinding = new BasicHttpsBinding();
                    httpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;
                    // No credential is needed to connect to the host service.
                    httpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

                    // EndPoint address 
                    EndpointAddress endpointAddress = new EndpointAddress(connection);
                    // Pass Binding and EndPoint address to ChannelFactory using httpBinding
                    channelFactory = new ChannelFactory<IAnimalService>(httpsBinding, endpointAddress);
                    // Now create the new channel as below
                    IAnimalService channel = channelFactory.CreateChannel();
                    return channel;

                }
                else if(connection.StartsWith("http"))
                {
                    // HTTP
                    // Create a binding of the type exposed by service  
                    BasicHttpBinding httpBinding = new BasicHttpBinding();
                    httpBinding.Security.Mode = BasicHttpSecurityMode.None;
                    // No credential is needed to connect to the host service.
                    httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

                    // EndPoint address 
                    EndpointAddress endpointAddress = new EndpointAddress(connection);
                    // Pass Binding and EndPoint address to ChannelFactory using httpBinding
                    channelFactory = new ChannelFactory<IAnimalService>(httpBinding, endpointAddress);
                    // Now create the new channel as below
                    IAnimalService channel = channelFactory.CreateChannel();
                    return channel;
                }

                throw new Exception("No valid connection protocol was found");

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
