using System;
using System.Linq.Expressions;

namespace Com.StarZ.Core.Jobs
{
    public interface IJobClient
    {
        /// <summary>
        /// Enqueues the specified action.
        /// </summary>
        /// <param name="action">The action to enqueue.</param>
        void Enqueue(Expression<Action> action);
    }
}