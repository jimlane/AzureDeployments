using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace RoleWithInternalEndpoint
{
    class SenderFromCode
    {
        IConversationChannel myChannel;
        ChannelFactory<IConversationChannel> myFactory;
        NetTcpBinding myBinding = new NetTcpBinding(SecurityMode.None, false);
        public string myAddress { get; set; }

        static void Main()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ConfigComms()
        {
            try
            {
                EndpointAddress myAddr = new EndpointAddress(string.Format("net.tcp://{0}/", myAddress));

                myFactory = new ChannelFactory<IConversationChannel>(myBinding, myAddr);
                myChannel = myFactory.CreateChannel();
                myChannel.Open(new TimeSpan(0, 2, 0));
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error configuring communication: " + ex.Message);
                throw;
            }
        }

        public bool SaySomething(string message)
        {
            if (myChannel.State == CommunicationState.Opened)
            {
                myChannel.Conversation(message);
            }
            return true;
        }
    }
}
