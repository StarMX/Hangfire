using System;
using System.Linq.Expressions;

namespace Com.StarZ.Core.Jobs
{
    public interface IBackgroundJobQueue
    {
        void Enqueue(Expression<Action> action);

        void Schedule(Expression<Action> expression, TimeSpan delay);

        void PurgeQueue();

        void EnqueueJobs();
    }
}