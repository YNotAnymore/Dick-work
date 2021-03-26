using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{

    public enum DicItem : byte
    {
        Normal = 1,
        Test = 2
    }

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var key = "Dic";

            //{
            //    Dictionary<byte, string> dictionaries = Configuration.GetSection(key).Get<Dictionary<byte, string>>();

            //    Console.WriteLine($"Dictionary<byte, string> count : {dictionaries.Count}");
            //}

            //{
            //    Dictionary<string, string> dictionaries = Configuration.GetSection(key).Get<Dictionary<string, string>>();

            //    Console.WriteLine($"Dictionary<string, string> count : {dictionaries.Count}");
            //}

            //{
            //    Dictionary<int, string> dictionaries = Configuration.GetSection(key).Get<Dictionary<int, string>>();

            //    Console.WriteLine($"Dictionary<int, string> count : {dictionaries.Count}");
            //}

            //{
            //    Dictionary<DicItem, string> dictionaries = Configuration.GetSection(key).Get<Dictionary<DicItem, string>>();

            //    Console.WriteLine($"Dictionary<DicItem, string> count : {dictionaries.Count}");
            //}

            { 
            

            
            }

            {

                IConfigurationSection configurationSection = Configuration.GetSection(key);

                Console.WriteLine(configurationSection.GetType().FullName);

                Dictionary<DicItem, string> dictionaries = ConfigurationBinder_sc.Get<Dictionary<DicItem, string>>(configurationSection);

                foreach (var item in dictionaries)
                {
                    Console.WriteLine($"{item.Key}:{item.Value}");
                }

            }

            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire");

            app.UseRouting();


            app.Run(context =>
            {
                IHttpMaxRequestBodySizeFeature httpMaxRequestBodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();

                Console.WriteLine(httpMaxRequestBodySizeFeature.IsReadOnly);
                Console.WriteLine(httpMaxRequestBodySizeFeature.MaxRequestBodySize);

                Console.WriteLine(httpMaxRequestBodySizeFeature.GetType().FullName);

                return Task.CompletedTask;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
