using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.HttpJob;
using Hangfire.LiteDB;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Com.StarZ
{
    public static class ServiceCollectionExtensions
    {

        public static void AddHangfire(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(configuration => configuration
                        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                        .UseSimpleAssemblyNameTypeSerializer()
                        .UseRecommendedSerializerSettings()
                        .UseHangfireHttpJob(new HangfireHttpJobOptions()
                        {
                            
                            AddHttpJobButtonName = "添加计划任务",
                            AddRecurringJobHttpJobButtonName = "添加定时任务",
                            EditRecurringJobButtonName = "编辑定时任务",
                            PauseJobButtonName = "暂停或开始",
                            DashboardTitle = "后台任务管理",
                            DashboardName = "后台任务管理",
                            DashboardFooter = string.Empty,
                            
                        })
                        .UseConsole(new ConsoleOptions()
                        {
                            BackgroundColor = "#000079"
                        })
                        .UseDashboardMetric(DashboardMetrics.AwaitingCount)
                        .UseDashboardMetric(DashboardMetrics.ProcessingCount)
                        .UseDashboardMetric(DashboardMetrics.RecurringJobCount)
                        .UseDashboardMetric(DashboardMetrics.RetriesCount)
                        .UseDashboardMetric(DashboardMetrics.FailedCount)
                        .UseDashboardMetric(DashboardMetrics.ServerCount)
                        .UseLiteDbStorage()
                        //.UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                        //{
                        //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        //    QueuePollInterval = TimeSpan.Zero,
                        //    UseRecommendedIsolationLevel = true,
                        //    UsePageLocksOnDequeue = true,
                        //    DisableGlobalLocks = true
                        //})
                        );

        }

        public static void AddHangfireServers(this IServiceCollection services)
        {
            services.AddHangfireServer(options =>
            {
                options.Queues = new[] { "default", "webhooks","api" };
                options.SchedulePollingInterval = TimeSpan.FromSeconds(5);
                options.WorkerCount = Environment.ProcessorCount * 5;
            });
        }
        public static IApplicationBuilder UseHangfireServices(this IApplicationBuilder builder)
        {
            builder.UseHangfireDashboard("/Hangfire", new DashboardOptions
            {
                DisplayStorageConnectionString = false,
                IsReadOnlyFunc = Context => false,
            });
            return builder;
        }



        /*
TRUNCATE TABLE [HangFire].[AggregatedCounter]
TRUNCATE TABLE [HangFire].[Counter]
TRUNCATE TABLE [HangFire].[JobParameter]
TRUNCATE TABLE [HangFire].[JobQueue]
TRUNCATE TABLE [HangFire].[List]
TRUNCATE TABLE [HangFire].[State]
DELETE FROM [HangFire].[Job]
DBCC CHECKIDENT ('[HangFire].[Job]', reseed, 0)
UPDATE [HangFire].[Hash] SET Value = 1 WHERE Field = 'LastJobId'
         */
    }
}
