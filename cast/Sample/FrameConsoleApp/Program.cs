using Aspose.Pdf;
using Newtonsoft.Json.Linq;
using NReco.VideoConverter;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameConsoleApp
{

    public class MyConvert  : FFMpegConverter
    {

        public void ShowArg()
        {
            var arg = base.ComposeFFMpegCommandLineArgs(@"F:\Davis\Data\voice\1.mp3", "amr", @"F:\Davis\Data\voice\1.mp3", "mp3", new ConvertSettings { AudioSampleRate = 44100 });
            Console.WriteLine(arg);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            { // pdf转word
                //PdfDocument doc = new PdfDocument();
                //doc.LoadFromFile(@"C:\Users\win\Documents\WeChat Files\sameheat\FileStorage\File\2020-10\《政治》.pdf");
                //doc.SaveToFile("qw.doc", FileFormat.DOC);
                //System.Diagnostics.Process.Start("qw.doc");
            }

            { // ddmpeg

                //new FFMpegConverter().ConvertMedia(@"F:\Davis\Data\voice\1.amr", "amr", @"F:\Davis\Data\voice\1.mp3", "mp3", new ConvertSettings { AudioSampleRate = 44100 });

                //MyConvert converter = new MyConvert();

                //converter.ShowArg();

            }

            {
                //// Open the source PDF document
                //Document pdfDocument = new Document(@"C:\Users\win\Documents\WeChat Files\sameheat\FileStorage\File\2020-10\《政治》.pdf");

                //// Save the file into MS document format
                //pdfDocument.Save("PDFToDOC_out.doc", SaveFormat.Doc);
            }

            Console.WriteLine("Hello World");

            Console.ReadKey(true);


        }
    }
}
