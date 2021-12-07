using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThing.AsposeModule
{
    /// <summary>
    /// @auth : monster
    /// @since : 2021/12/1 星期三 23:07:56
    /// @source : 
    /// @des : 
    /// </summary>
    public class AsposeTest
    {

        public static void Test()
        {
            // 插入图片

            Aspose.Words.Document doc = new Aspose.Words.Document();
            DocumentBuilder docBuilder = new DocumentBuilder(doc);
            docBuilder.InsertHtml("<p><img src='https://imagepphcloud.thepaper.cn/pph/image/164/388/362.jpg' data-index='0' data-width='1024px' data-height='604px'></p>");
            docBuilder.InsertHtml("<b>123123 测试插入</b>");

            using var steam = File.Create($@"D:\data\empty\{Guid.NewGuid()}.docx");

            doc.Save(steam, SaveFormat.Docx);

        }

    }
}
