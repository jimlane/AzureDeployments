using System;
using System.ServiceModel;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace RoleWithInternalEndpoint
{
    class ReceiverFromCode
    {
        private ServiceHost mySvc;
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
                // Configure inter-role communication
                mySvc = new ServiceHost(typeof(ReceiverProxy));
                var netTcpBinding = new NetTcpBinding(SecurityMode.None, false)
                {
                    HostNameComparisonMode = HostNameComparisonMode.Exact
                };
                mySvc.AddServiceEndpoint(typeof(IConversation), netTcpBinding, string.Format("net.tcp://{0}/", myAddress));
                mySvc.Open();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error configuring communication: " + ex.Message);
                throw;
            }
        }
    }
}
