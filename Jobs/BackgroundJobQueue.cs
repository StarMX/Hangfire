using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using Hangfire;

namespace Com.StarZ.Core.Jobs
{
    /// <summary>
    /// The background job queue.
    /// </summary>
    public class BackgroundJobQueue : IBackgroundJobQueue
    {
        private readonly IHangfireClient client;

        private ConcurrentBag<Job> jobs;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundJobQueue"/> class.
        /// </summary>
        /// <param name="client">The hangfire client.</param>
        public BackgroundJobQueue(IHangfireClient client)
        {
            this.client = client;

            jobs = new ConcurrentBag<Job>();
        }

        /// <summary>
        /// Creates a background job based on an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public void Enqueue(Expression<Action> expression)
        {
            var job = new Job
            {
                Expression = expression
            };

            jobs.Add(job);
        }

        /// <summary>
        /// Schedules a job to be enqueued after the specified delay.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="delay">
        /// A time span indicating how long to delay until a job is enqueued.
        /// </param>
        public void Schedule(Expression<Action> expression, TimeSpan delay)
        {
            var job = new Job
            {
                Expression = expression,
                Delay      = delay
            };

            jobs.Add(job);
        }

        /// <summary>
        /// Purges all the jobs from the queue.
        /// </summary>
        public void PurgeQueue()
        {
            jobs = new ConcurrentBag<Job>();
        }

        /// <summary>
        /// Enqueues all jobs.
        /// </summary>
        public void EnqueueJobs()
        {
            foreach (var job in jobs)
            {
                if (job.Delay.HasValue)
                {
                    // Handle jobs that have been delayed:
                    client.Instance.Schedule(job.Expression, job.Delay.Value);
                }
                else
                {
                    client.Instance.Enqueue(job.Expression);
                    
                }
            }
            jobs.Clear();
        }
    }
}