using Com.StarZ.Core.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;


namespace Com.StarZ.Hangfire
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHostLifetime, TopshelfLifetime>();


#if DEBUG

            services.AddSingleton<IHangfireClient, HangfireClient>();
            services.AddSingleton<IJobClient, JobClient>();
            services.AddSingleton<IBackgroundJobQueue, BackgroundJobQueue>();


            services.AddTransient<IDemo, Demo>();
            services.AddHostedService<TestService>();
            services.AddMediatorServices();
#endif
            services.AddHangfire(Configuration.GetConnectionString("HangfireConnection"));
            services.AddHangfireServers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/Hangfire");
                    await Task.CompletedTask;
                });
            });
        }
    }
}
