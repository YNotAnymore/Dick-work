using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerDemoApi.SwaggerAttr
{
    /// <summary>
    /// ignore some api on swagger.json
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
