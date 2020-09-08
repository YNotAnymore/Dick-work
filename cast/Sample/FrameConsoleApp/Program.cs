using Newtonsoft.Json.Linq;
using NReco.VideoConverter;
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
            {

                //new FFMpegConverter().ConvertMedia(@"F:\Davis\Data\voice\1.amr", "amr", @"F:\Davis\Data\voice\1.mp3", "mp3", new ConvertSettings { AudioSampleRate = 44100 });

                MyConvert converter = new MyConvert();

                converter.ShowArg();

            }

            Console.WriteLine("Hello World");

            Console.ReadKey(true);


        }
    }
}
