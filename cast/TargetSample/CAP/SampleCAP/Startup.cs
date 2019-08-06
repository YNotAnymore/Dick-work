using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderAppContext;
using SampleCAP.Subscribe;

namespace SampleCAP
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
            services.AddDbContext<OrderDbContext>((builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }));

            // 实现接口方式需要在AddCap之前AddTransient
            // 实现接口方式优先于Controller
            services.AddTransient<IMsgSubscribe, MsgSubscribe>();

            services.AddCap(x =>
            {
                //如果你使用的 EF 进行数据操作，你需要添加如下配置：
                //x.UseEntityFramework<OrderDbContext>();  //可选项，你不需要再次配置 x.UseSqlServer 了

                //如果你使用的ADO.NET，根据数据库选择进行配置：
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                //x.UseMySql("数据库连接字符串");
                //x.UsePostgreSql("数据库连接字符串");

                //如果你使用的 MongoDB，你可以添加如下配置：
                //x.UseMongoDB("ConnectionStrings");  //注意，仅支持MongoDB 4.0+集群

                //CAP支持 RabbitMQ、Kafka、AzureServiceBus 等作为MQ，根据使用选择配置：
                //x.UseRabbitMQ("ConnectionStrings");
                x.UseRabbitMQ(s =>
                {
                    s.HostName = Configuration["RabbitMQ:HostName"];
                    s.UserName = Configuration["RabbitMQ:UserName"];
                    s.Password = Configuration["RabbitMQ:Password"];
                });

                //x.UseKafka("ConnectionStrings");
                //x.UseAzureServiceBus("ConnectionStrings");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}