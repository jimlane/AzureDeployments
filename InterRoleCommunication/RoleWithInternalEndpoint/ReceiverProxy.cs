using System.Diagnostics;
using System.ServiceModel;

namespace RoleWithInternalEndpoint
{
    [ServiceBehavior]
    class ReceiverProxy : IConversation
    {
        public string Conversation(string Message)
        {
            Trace.TraceInformation("Received: " + Message);
            return "You said: " + Message;
        }
    }

}
