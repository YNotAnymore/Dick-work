using FfmpegDemo.External;
using System;

namespace FfmpegDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string param, res;

            var path = @"F:\Davis\Github\Cat_Lov\cast\Sample\FfmpegDemo\External\ffmpeg.exe";

            // 水印
            //var param = @"-i Data\vedio.mp4 -i Data\a.gif -filter_complex ""overlay=10:10"" newVedio.mp4";

            // 视频拼接

            #region 相同尺寸合并
            //var param = @"-f concat -i contact.txt -c copy contact.mp4";

            //var param = @"-f concat -i contact.txt -c:v libx264 -crf 23 -profile:v high -level 5 -c:a aac -b:a 240k contact.mp4";
            #endregion

            #region 不同尺寸合并
            param = "-i vedio.mp4 -c copy -bsf:v h264_mp4toannexb -f mpegts 1.ts";
            //param = "- i vedio.mp4 - f mpegts - codec:v mpeg1video -codec:a mp2 -b 0 1.ts";
            res = FfmpegHelper.RunProcessPrintTime(path, param);
            Console.WriteLine(res);

            param = "-i PC-video.mp4 -c copy -bsf:v h264_mp4toannexb -b:v 500k -f mpegts 2.ts";
            res = FfmpegHelper.RunProcessPrintTime(path, param);
            Console.WriteLine(res);

            param = @"-i ""concat:1.ts|2.ts"" -c copy -bsf:a aac_adtstoasc -movflags +faststart -c copy contact.mp4";
            res = FfmpegHelper.RunProcessPrintTime(path, param);
            #endregion

            Console.WriteLine(res);

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }
    }
}
