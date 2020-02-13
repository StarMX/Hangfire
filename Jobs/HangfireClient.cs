using System;
using Hangfire;

namespace Com.StarZ.Core.Jobs
{
    /// <summary>
    /// A Lazily initialized Hangfire client.
    /// </summary>
    public class HangfireClient : IHangfireClient
    {
        private readonly Lazy<BackgroundJobClient> lazyClient = new Lazy<BackgroundJobClient>();

        public BackgroundJobClient Instance => lazyClient.Value;
    }
}