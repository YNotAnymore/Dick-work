using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SwaggerDemoApi.SwaggerConfig
{
    public class XmlInfo
    {
        public XPathDocument Document { get; set; }

        public XmlInfo(XPathDocument xPath)
        {
            this.Document = xPath;
        }
    }
}
