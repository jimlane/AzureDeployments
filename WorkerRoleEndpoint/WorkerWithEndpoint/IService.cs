using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WorkerWithEndpoint
{
    [ServiceContract]

    public interface IService

    {
        [OperationContract]
        [WebGet]
        string GetMessage(string inputMessage);

        [OperationContract]
        [WebInvoke]
        string PostMessage(string inputMessage);
    }
}
