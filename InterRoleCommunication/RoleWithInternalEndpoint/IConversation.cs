using System;
using System.ServiceModel;

namespace RoleWithInternalEndpoint
{
    [ServiceContract]
    public interface IConversation
    {
        [OperationContract]
        string Conversation(string Message);
    }

    public interface IConversationChannel : IConversation, IClientChannel { }
}
