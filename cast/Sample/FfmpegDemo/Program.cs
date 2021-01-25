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
            //param = "-i vedio.mp4 -c copy -bsf:v h264_mp4toannexb -f mpegts 1.ts";
            ////param = "- i vedio.mp4 - f mpegts - codec:v mpeg1video -codec:a mp2 -b 0 1.ts";
            //res = FfmpegHelper.RunProcessPrintTime(path, param);
            //Console.WriteLine(res);

            //param = "-i PC-video.mp4 -c copy -bsf:v h264_mp4toannexb -b:v 500k -f mpegts 2.ts";
            //res = FfmpegHelper.RunProcessPrintTime(path, param);
            //Console.WriteLine(res);

            //param = @"-i ""concat:1.ts|2.ts"" -c copy -bsf:a aac_adtstoasc -movflags +faststart -c copy contact.mp4";
            //res = FfmpegHelper.RunProcessPrintTime(path, param);
            #endregion

            #region amr -> mp3

            //param = @"-y -i ""F:\Davis\Data\voice\1.amr"" ""F:\Davis\Data\voice\1.mp3""";
            //param = @"-y -loglevel info  -f amr -i ""F:\Davis\Data\voice\1.amr""  -f mp3  -ar 44100 ""F:\Davis\Data\voice\1.mp3""";
            //param = @"-y -loglevel info  -f amr -i ""F:\Davis\Data\voice\1.amr""  -f mp3  ""F:\Davis\Data\voice\1.mp3""";
            //res = FfmpegHelper.RunProcessPrintTime(path, param);

            #endregion


            //param = @"-i F:\Davis\Data\voice\1.amr";
            //param = @"-i https://m801.music.126.net/20200826104543/a57d4bb013ca51c70b27256688f435aa/jdyyaac/0659/535b/525a/134403a105d1cf770b52e0234058ff53.m4a";
            //param = @"-i http://132.232.105.129:8080/uploads/voice/2020/8/31/2443e30d26c74947b515df1967098ada.mp3";
            //res = FfmpegHelper.RunProcessPrintTime(path, param);

            //Console.WriteLine(res);

            #region 获取mp3长度

            //int duration = FfmpegHelper.GetDurationByffmpeg(@"http://132.232.105.129:8080/uploads/voice/2020/8/31/2443e30d26c74947b515df1967098ada.mp3", path);

            //Console.WriteLine(duration);

            #endregion

            #region mp3转pcm

            param = "-y -i test.mp3 -acodec pcm_s16le -f s16le -ac 2 -ar 16000 test.pcm";

            res = FfmpegHelper.RunProcessPrintTime(path, param);

            Console.WriteLine(res);

            param = "-y -f s16be -ac 2 -ar 16000 -acodec pcm_s16le -i test.pcm new_mp3.mp3";

            res = FfmpegHelper.RunProcessPrintTime(path, param);

            Console.WriteLine(res);

            param = "-i test.mp3 -f wav test.wav";

            res = FfmpegHelper.RunProcessPrintTime(path, param);

            Console.WriteLine(res);

            #endregion

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);
        }
    }
}
