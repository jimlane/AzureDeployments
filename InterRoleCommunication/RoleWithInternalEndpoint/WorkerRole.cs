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
using System.ServiceModel.Description;

namespace RoleWithInternalEndpoint
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private SenderFromCode mySender;
        private ReceiverFromCode myReceiver;

        public override void Run()
        {
            Trace.TraceInformation("RoleWithInternalEndpoint is running");

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

            // Setup communications with other roles
            ConfigInterRoleComms();

            bool result = base.OnStart();

            Trace.TraceInformation("RoleWithInternalEndpoint has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("RoleWithInternalEndpoint is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("RoleWithInternalEndpoint has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                
                mySender.SaySomething("Role " + RoleEnvironment.CurrentRoleInstance.Id.ToString() + " says Hello World!");
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }

        private bool ConfigInterRoleComms()
        {
            try
            {
                // Configure receiver
                myReceiver = new ReceiverFromCode();
                myReceiver.myAddress = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["internalEndpoint"].IPEndpoint.ToString();
                myReceiver.ConfigComms();

                // Configure sender
                mySender = new SenderFromCode();
                mySender.myAddress = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["internalEndpoint"].IPEndpoint.ToString();
                return mySender.ConfigComms();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error configuring communication: " + ex.Message);
                throw;
            }

        }
    }
}
