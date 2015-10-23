using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WorkerWithEndpoint
{
    public class Service : IService
    {
        public string GetMessage(string inputMessage)
        {
            return "Calling Get for you " + inputMessage;
        }

        public string PostMessage(string inputMessage)
        {
            return "Calling Post for you " + inputMessage;
        }

    }
}
