using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiSample.MsgHandle;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.AspectScope;
using AspectCore.Injector;

namespace WebApiSample
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
            services.AddCap(option => {

                option.UseDashboard();

                option.UseRabbitMQ(config =>
                {
                    config.HostName = "";
                    config.Port = 1001;
                    config.Password = "";
                    config.UserName = "";
                    config.VirtualHost = "";
                });

                option.UseSqlServer(Configuration.GetConnectionString("UArea"));

            });
            services.AddTransient<TestHandler>();

            #region Interceptor

            services.AddAspectScope();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        /// <summary>
        /// ≈‰÷√Autofac»›∆˜
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Member>().As<IWork>();
        }

    }

    public interface IWork
    {
        void Run();
    }

    public class Member : IWork
    {
        public void Run()
        {
            Console.WriteLine("I'm Working");
        }
    }



}
