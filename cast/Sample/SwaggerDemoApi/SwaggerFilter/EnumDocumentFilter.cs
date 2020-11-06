using Microsoft.OpenApi.Models;
using SwaggerDemoApi.Extension;
using SwaggerDemoApi.Menu;
using SwaggerDemoApi.SwaggerAttr;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace SwaggerDemoApi.SwaggerFilter
{

    public class EnumDocumentFilter : IDocumentFilter
    {
        private static Dictionary<string, Action<OpenApiSchema>> _cache = new Dictionary<string, Action<OpenApiSchema>>();

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var ignoreApis = context.ApiDescriptions.Where(wh => wh.CustomAttributes().Any(any => any is SwaggerIgnoreAttribute));
            if (ignoreApis != null)
            {
                foreach (var ignoreApi in ignoreApis)
                {
                    swaggerDoc.Paths.Remove("/" + ignoreApi.RelativePath);
                }
            }

            //foreach (var item in swaggerDoc.Paths.Values.SelectMany(u => u.Operations).Where(u => u.Key == OperationType.Get))
            //{
            //    foreach (var param in item.Value.Parameters)
            //    {
            //        param.Schema.Reference = null;
            //        param.Schema.Type = "string";
            //        param.Description = "test";
            //    }
            //}

            //Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription[] apiDescriptions = context.ApiDescriptions.ToArray();

            //foreach (var apiDesc in context.ApiDescriptions.Where(u => u.HttpMethod == HttpMethod.Get.ToString()))
            //{
            //    foreach (var item in apiDesc.ParameterDescriptions.Where(u => u.Type.IsEnum))
            //    {
            //        item.IsRequired = true;
            //        item.DefaultValue = "test2";
            //    }
            //}
            Assembly assembly = typeof(Level).Assembly;
            IDictionary<string, OpenApiSchema> schemas = swaggerDoc.Components.Schemas;
            foreach (var item in schemas)
            {
                var property = item.Value;

                if (property.Enum != null && property.Enum.Count > 0)
                {

                    if (_cache.ContainsKey(item.Key))
                    {
                        _cache[item.Key](property);
                    }
                    else
                    {
                        Type type = assembly.GetType(item.Key);

                        bool flag = type.GetCustomAttribute<SeariesToStringAttribute>() != null;
                        string desc = flag ? EnumExt.DescribeStrEnum(type) : EnumExt.DescribeIntEnum(type);
                        Action<OpenApiSchema> action;
                        if (flag)
                        {
                            action = prop =>
                            {
                                prop.Description = desc;
                                prop.Type = "string";
                                prop.Format = null;
                            };
                        }
                        else
                        {
                            action = prop => { prop.Description = desc; };
                        }


                        action(property);

                        _cache[item.Key] = action;

                    }

                    if (property.Description != null)
                        property.Enum.Clear();

                }


            }

        }

    }
}
