using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WorkerWithEndpoint
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerWithEndpoint is running");

            // NOTE - worker role must be run with elevated priveledges for this to work!
            WebServiceHost serviceHost = new WebServiceHost(typeof(Service));
            WebHttpBinding binding = new WebHttpBinding(WebHttpSecurityMode.None);
            binding.HostNameComparisonMode = HostNameComparisonMode.Exact;

            RoleInstanceEndpoint externalEndPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["myEndpoint"];
            string endpoint = String.Format("http://{0}/HelloService", externalEndPoint.IPEndpoint);
            Trace.WriteLine("Opening host", endpoint);
            serviceHost.AddServiceEndpoint(typeof(IService), binding, endpoint);
            serviceHost.Open();

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerWithEndpoint has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerWithEndpoint is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerWithEndpoint has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
