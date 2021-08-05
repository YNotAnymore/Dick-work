using Hangfire;
using Hangfire.MemoryStorage;
using HangfireDemo.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HangfireDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });
            services.AddTransient<IJob, TestJob2>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHangfireDashboard();

            app.UseHangfireServer(new BackgroundJobServerOptions {
                SchedulePollingInterval = TimeSpan.FromSeconds(1)
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //RecurringJob.AddOrUpdate<TestJob>(u => u.Run(), "0/2 * * * * *");

            // 拦截生效
            //RecurringJob.AddOrUpdate<IJob>(u => u.RunAsync(), "0/1 * * * * *");

            // 拦截不生效
            //RecurringJob.AddOrUpdate<TestJob2>(u => u.RunAsync(), "0/1 * * * * *");

            // 拦截生效
            //RecurringJob.AddOrUpdate<TestJob3>(u => u.RunAsync(), "0/1 * * * * *");
            RecurringJob.AddOrUpdate<TestJob3>(u => u.RunAsync(), "0 0 */1 * * *");

        }
    }
}
