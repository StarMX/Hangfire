using System;
using System.Linq.Expressions;

namespace Com.StarZ.Core.Jobs
{
    public class Job
    {
        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        public Expression<Action> Expression { get; set; }

        /// <summary>
        /// Gets or sets an optional timespan that will delay the job's execution.
        /// </summary>
        public TimeSpan? Delay { get; set; }
    }
}