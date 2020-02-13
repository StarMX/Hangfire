#if  DEBUG 
using Com.StarZ.Core.Jobs;
using Hangfire;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Com.StarZ.Hangfire
{
    class TestService : IHostedService
    {


        private readonly IHangfireClient hangfireClient;
        private readonly IDemo demo;

        //private readonly IMediator mediator;
        public TestService(IDemo _demo, /*IMediator _mediator,*/ IHangfireClient _hangfireClient)
        {
            hangfireClient = _hangfireClient;
            demo = _demo;
            //mediator = _mediator;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            //jobClient.Enqueue(() => Console.WriteLine(DateTime.Now.ToString()));
            //backgroundJobQueue.EnqueueJobs();

            //mediator.Publish(new Com.StarZ.MediatR.DemoNotification() { Message = "hahahah" });

            //var r = mediator.Send(new Com.StarZ.MediatR.DemoRequest() { Message = "tttttt" });
            //Console.WriteLine(r.Result.Message);
            RecurringJob.AddOrUpdate("Demo", () => demo.Add(), "*/5 * * * * *");
            RecurringJob.AddOrUpdate(typeof(IDemo).FullName, () => demo.DoWork(), "*/30 * * * * *");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            RecurringJob.RemoveIfExists("Demo");
            RecurringJob.RemoveIfExists(typeof(IDemo).FullName);
            return Task.CompletedTask;
        }
    }

    interface IDemo
    {
        void Add();
        void DoWork();
    }

    class Demo : IDemo
    {
        private readonly IJobClient jobClient;
        private readonly IBackgroundJobQueue backgroundJobQueue;
        //private readonly IMediator mediator;
        public Demo(IBackgroundJobQueue _backgroundJobQueue, IJobClient _jobClient/*, IMediator _mediator*/)
        {
            jobClient = _jobClient;
            backgroundJobQueue = _backgroundJobQueue;
            //mediator = _mediator;
        }

        public void Add()
        {
            //mediator.Publish(new Com.StarZ.MediatR.DemoNotification() { Message = DateTime.Now.ToString()});
            Console.WriteLine($"Add {DateTime.Now.ToString()}");
            jobClient.Enqueue(() => Console.WriteLine($"JOB {DateTime.Now.ToString()}"));
        }

        public void DoWork()
        {
            Console.WriteLine($"DoWork  {DateTime.Now.ToString()}");
            backgroundJobQueue.EnqueueJobs();
        }
    }
}
#endif