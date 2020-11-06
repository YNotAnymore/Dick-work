using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using SwaggerDemoApi.SwaggerConfig;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SwaggerDemoApi.SwaggerFilter
{
    public class ControllerDocumentFilter : IDocumentFilter
    {
        private static List<OpenApiTag> _tags;
        private readonly XmlInfo xmlInfo;

        public ControllerDocumentFilter(XmlInfo xmlInfo)
        {
            this.xmlInfo = xmlInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

            if (_tags != null)
            {
                swaggerDoc.Tags = _tags;
                return;
            }

            XPathNavigator xPathNavigator = xmlInfo.Document.CreateNavigator();

            Assembly assembly = Assembly.GetExecutingAssembly();

            _tags = new List<OpenApiTag>();

            var baseType = typeof(ControllerBase);

            assembly.GetTypes().Where(u => u.IsClass && !u.IsAbstract && baseType.IsAssignableFrom(u)).Select(u =>
            {

                string value = xPathNavigator.SelectSingleNode($"doc/members/member[@name='T:{u.FullName}']/summary")?.Value;

                if (!string.IsNullOrEmpty(value))
                {
                    var name = u.Name;
                    var len = "Controller".Length;
                    ReadOnlySpan<char> readOnlySpan = name.AsSpan(0, name.Length - len);
                    _tags.Add(new OpenApiTag { Name = readOnlySpan.ToString(), Description = value });
                }

                return u;

            }).ToArray();

            swaggerDoc.Tags = _tags;
        }
    }
}
