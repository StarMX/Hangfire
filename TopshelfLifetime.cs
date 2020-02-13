using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Com.StarZ.Hangfire
{
    internal class TopshelfLifetime : IHostLifetime
    {

        public TopshelfLifetime(IHostApplicationLifetime applicationLifetime, IServiceProvider services)
        {
            ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        private IHostApplicationLifetime ApplicationLifetime { get; }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
