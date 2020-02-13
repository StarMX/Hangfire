using System;
using System.Linq.Expressions;

namespace Com.StarZ.Core.Jobs
{
    public class JobClient : IJobClient
    {
        private readonly IBackgroundJobQueue queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobClient"/> class.
        /// </summary>
        /// <param name="queue">The background queue.</param>
        public JobClient(IBackgroundJobQueue queue)
        {
            this.queue = queue;
        }

        /// <summary>
        /// Creates a background job based on an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public void Enqueue(Expression<Action> expression)
        {
            queue.Enqueue(expression);
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
            queue.Schedule(expression, delay);
        }
    }
}