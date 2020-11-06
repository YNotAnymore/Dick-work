using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwaggerDemoApi.SeariesMiddleware
{
    /// <summary>
    /// 可选JsonConvert工厂
    /// </summary>
    public class OptionalJsonConvertFactory : JsonConverterFactoryDecorator
    {
        private readonly Type[] attrTypes;

        public OptionalJsonConvertFactory(JsonConverterFactory innerFactory, params Type[] attrTypes) : base(innerFactory)
        {
            this.attrTypes = attrTypes;
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return base.CanConvert(typeToConvert) && attrTypes.Any(u => typeToConvert.GetCustomAttribute(u) != null);
        }
    }

    /// <summary>
    /// JsonConvert工厂装饰器
    /// </summary>
    public class JsonConverterFactoryDecorator : JsonConverterFactory
    {
        readonly JsonConverterFactory innerFactory;

        public JsonConverterFactoryDecorator(JsonConverterFactory innerFactory)
        {
            this.innerFactory = innerFactory ?? throw new ArgumentNullException(nameof(innerFactory));
        }
        public override bool CanConvert(Type typeToConvert) => innerFactory.CanConvert(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return innerFactory.CreateConverter(typeToConvert, options);
        }
    }
}
