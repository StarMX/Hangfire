using Hangfire;

namespace Com.StarZ.Core.Jobs
{
    public interface IHangfireClient
    {
        BackgroundJobClient Instance { get; }
    }
}