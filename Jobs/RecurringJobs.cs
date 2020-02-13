using Hangfire;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Com.StarZ.Core.Jobs
{
    /// <summary>
    /// Static class used to add, update, or remove recurring jobs.
    /// </summary>
    public static class DXRecurringJobs
    {
        public static void AddOrUpdate(Expression<Action> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(string recurringJobIdentity, Expression<Func<T, Task>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(string recurringJobIdentity, Expression<Func<Task>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(string recurringJobIdentity, Expression<Func<T, Task>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(string recurringJobIdentity, Expression<Func<Task>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(Expression<Func<T, Task>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(Expression<Func<Task>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(Expression<Func<T, Task>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(Expression<Func<Task>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(string recurringJobIdentity, Expression<Action<T>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(string recurringJobIdentity, Expression<Action> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(string recurringJobIdentity, Expression<Action<T>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(string recurringJobIdentity, Expression<Action> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(recurringJobIdentity, methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(Expression<Action<T>> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate(Expression<Action> methodCall, string cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate(methodCall, cronExpression, timeZone, queue);
        }

        public static void AddOrUpdate<T>(Expression<Action<T>> methodCall, Func<string> cronExpression, TimeZoneInfo timeZone = null, string queue = "default")
        {
            RecurringJob.AddOrUpdate<T>(methodCall, cronExpression, timeZone, queue);
        }
    }
}