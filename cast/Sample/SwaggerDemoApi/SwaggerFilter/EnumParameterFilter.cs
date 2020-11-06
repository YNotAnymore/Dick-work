using Microsoft.OpenApi.Models;
using SwaggerDemoApi.Extension;
using SwaggerDemoApi.SwaggerAttr;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace SwaggerDemoApi.SwaggerFilter
{
    public class EnumParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (context.ParameterInfo.ParameterType.IsEnum)
            {
                var type = context.ParameterInfo.ParameterType;
                if (type.GetCustomAttribute<SeariesToStringAttribute>() != null)
                {
                    parameter.Schema.Type = "string";
                    parameter.Schema.Reference = null;
                    parameter.Description = EnumExt.DescribeStrEnum(type);
                }
                else
                {
                    parameter.Schema.Type = "string/int";
                    parameter.Schema.Reference = null;
                    parameter.Description = EnumExt.DescribeEnum(type);
                }
            }
        }
    }
}
