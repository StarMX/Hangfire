using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Topshelf;

namespace Com.StarZ.Hangfire
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
            HostFactory.Run(x =>
            {
                x.SetServiceName("HangfireHostWindowsServiceWithTopshelf");
                x.SetDisplayName("Topshelf创建的Hangfire Host服务");
                x.SetDescription("运行Topshelf创建的Hangfire Host服务");
                x.Service<IHost>(s =>
                {
                    s.ConstructUsing(() => builder.Build());
                    s.WhenStarted(service =>{service.Start();});
                    s.WhenStopped(service =>{service.StopAsync();});
                });
            });


            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            //    .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
            //    .Build();


            //var collection = new ServiceCollection();

            //collection.AddScoped<IHangfireClient, HangfireClient>();
            //collection.AddScoped<IJobClient, JobClient>();
            //collection.AddScoped<IBackgroundJobQueue, BackgroundJobQueue>();
            //var connection = configuration.GetConnectionString("HangfireConnection");
            //Console.WriteLine(connection);
            ////services.AddSingleton<IHostLifetime, TopshelfLifetime>();
            //collection.AddHangfire(configuration => configuration
            //.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //.UseSimpleAssemblyNameTypeSerializer()
            //.UseRecommendedSerializerSettings()
            //.UseSqlServerStorage(connection, new SqlServerStorageOptions
            //{
            //    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //    QueuePollInterval = TimeSpan.Zero,
            //    UseRecommendedIsolationLevel = true,
            //    UsePageLocksOnDequeue = true,
            //    DisableGlobalLocks = true
            //}));

            //collection.AddHangfireServer();
            //collection.AddHostedService<TestService>();
            //ServiceProvider buildServiceProvider = collection.BuildServiceProvider();




            //var builder = new HostBuilder()
            //    .ConfigureAppConfiguration((hostContext, app) =>
            //    {
            //        app.AddJsonFile("appsettings.json", true);
            //    })
            //    .ConfigureServices((hostContext, services) =>
            //    {
            //        services.AddSingleton<IHostLifetime, TopshelfLifetime>();
            //        services.AddSingleton<IHangfireClient, HangfireClient>();
            //        services.AddSingleton<IJobClient, JobClient>();
            //        services.AddTransient<IDemo, Demo>();
            //        services.AddSingleton<IBackgroundJobQueue, BackgroundJobQueue>();
            //        services.AddHangfire(hostContext.Configuration.GetConnectionString("HangfireConnection"));
            //        services.AddHangfireServers();
            //        services.AddMediatorServices();
            //        services.AddHostedService<TestService>();
            //    });

        }
    }
}
