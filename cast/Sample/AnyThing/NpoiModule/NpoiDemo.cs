using NPOI.SS.UserModel;
using NPOI.SS.UserModel.Charts;
using NPOI.SS.Util;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThing.NpoiModule
{
    /// <summary>
    /// @auth : monster
    /// @since : 2021/12/1 星期三 22:14:44
    /// @source : 
    /// @des : 
    /// </summary>
    public class NpoiDemo
    {

        public static void Run()
        {

            using var steam = File.OpenRead(@"E:\Data\xlsx\template.xlsx");

            XSSFWorkbook book = new XSSFWorkbook(steam);

            ISheet sheet = book.GetSheetAt(0);

            IDrawing drawing = sheet.CreateDrawingPatriarch();

            using var saveSteam = File.Create(@$"D:\data\empty\{Guid.NewGuid()}.xlsx");
            book.Write(saveSteam);

            saveSteam.Position = 0;

            //SXSSFWorkbook xSSFWorkbook = new SXSSFWorkbook(book);

            //xSSFWorkbook.GetSheetAt(0);

        }

        public static void TestSave()
        {
            SXSSFWorkbook xSSFWorkbook = new SXSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = xSSFWorkbook.CreateSheet("test");

            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("empty");
            row.CreateCell(1).SetCellValue("empty1");
            row.CreateCell(2).SetCellValue("empty2");

            using (var stream = new MemoryStream())
            {
                xSSFWorkbook.Write(stream);

                var vs = stream.ToArray();

                #region fix office打开时文档损坏 --- 
                using var memoryStream = new MemoryStream();
                memoryStream.Write(vs);
                memoryStream.Position = 0;

                XSSFWorkbook xSSFWorkbook2 = new XSSFWorkbook(memoryStream);

                using var memoryStream2 = new MemoryStream();
                xSSFWorkbook2.Write(memoryStream2);
                byte[] vs2 = memoryStream2.ToArray();
                #endregion

            }

            //using FileStream fileStream = File.Create("test.xlsx");

            //xSSFWorkbook.Write(fileStream);

        }
        public static void TestXWPFDocument()
        {
            XWPFDocument doc = new XWPFDocument();
            XWPFParagraph xWPFParagraph = doc.CreateParagraph();

            XWPFRun xWPFRun = xWPFParagraph.CreateRun();

            //using (var pic = File.OpenRead(@"D:\data\img\QQ图片20200404161057.jpg"))
            //{
            //    xWPFRun.AddPicture(pic, (int)NPOI.XWPF.UserModel.PictureType.JPEG, "test", 1000, 1000);
            //}

            xWPFRun.AppendText("test");

            using (var pic = File.OpenRead(@"D:\data\img\QQ图片20200404161057.jpg"))
            {
                xWPFRun.AddPicture(pic, (int)NPOI.XWPF.UserModel.PictureType.JPEG, "test", 5300000, 2500000);
            }

            using var steam = File.Create($@"D:\data\empty\{Guid.NewGuid()}.docx");

            doc.Write(steam);
        }
    }
}
