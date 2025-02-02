using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SwaggerDemoApi.SeariesMiddleware;
using SwaggerDemoApi.SwaggerAttr;
using SwaggerDemoApi.SwaggerConfig;
using SwaggerDemoApi.SwaggerFilter;

namespace SwaggerDemoApi
{

    public class GuidConverter : JsonConverter<Guid>
    {

        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str)) return default;
            if (Guid.TryParse(str, out var guid))
            {
                return guid;
            }
            else
            {
                return default;
            }
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            if (value == default)
            {
                writer.WriteNullValue();
                return;
            }
            writer.WriteStringValue(value.ToString("N"));
        }
    }

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
            services.AddControllers()
               //序列化JSON设置
               .AddJsonOptions(options =>// 序列化配置
               {
                   options.JsonSerializerOptions.WriteIndented = false;
                   options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

                   //首字母小写
                   options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                   options.JsonSerializerOptions.Converters.Add(new OptionalJsonConvertFactory(
                       new JsonStringEnumConverter(JsonNamingPolicy.CamelCase), typeof(SeariesToStringAttribute)));

                   options.JsonSerializerOptions.Converters.Add(new GuidConverter());

               });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {

                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (var item in context.ModelState.Values)
                    {
                        foreach (var sub in item.Errors)
                        {
                            stringBuilder.Append($"{sub.ErrorMessage}<br>");
                        }
                    }

                    return new JsonResult(stringBuilder.ToString());
                };
            });

            {// 注册swagger

                services.AddSingleton((u) => new XmlInfo(new XPathDocument(Path.Combine(AppContext.BaseDirectory, "Doc.xml"))));

                services.AddSwaggerGen(s =>
                {
                    // 使用全路径，避免相同类名异常
                    s.CustomSchemaIds(x => x.FullName);
                    s.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Api文档",
                        Version = "v1"
                    });
                    //s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    //{
                    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    //    Name = "Authorization",
                    //    In = ParameterLocation.Header,
                    //    Type = SecuritySchemeType.ApiKey
                    //});
                    //s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    //{
                    //    {
                    //        new OpenApiSecurityScheme
                    //        {
                    //            Reference = new OpenApiReference
                    //            {
                    //                Type = ReferenceType.SecurityScheme,
                    //                Id = "Bearer"
                    //            },
                    //            Scheme = "oauth2",
                    //            Name = "Bearer",
                    //            In = ParameterLocation.Header,

                    //        },
                    //        new List<string>()
                    //    }
                    //});

                    string xmlPath = Path.Combine(AppContext.BaseDirectory, "Doc.xml");

                    s.IncludeXmlComments(xmlPath);
                    s.DocumentFilter<EnumDocumentFilter>();
                    s.DocumentFilter<ControllerDocumentFilter>();
                    s.ParameterFilter<EnumParameterFilter>();
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            {
                //启用swagger
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "my app v1");
                });
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
