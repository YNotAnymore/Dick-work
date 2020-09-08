using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FfmpegDemo.External
{
    public static class FfmpegHelper
    {

        public static string RunProcessPrintTime(string path, string Parameters)
        {
            var guid = Guid.NewGuid().ToString();
            Console.WriteLine($"<{guid}>start time : {DateTime.Now:hh:MM:ss:fff}");
            var res = RunProcess(path, Parameters);
            Console.WriteLine($"<{guid}>end time : {DateTime.Now:hh:MM:ss:fff}");
            return res;
        }

        /// <summary>
        /// 调用ffmpeg.exe 执行命令
        /// </summary>
        /// <param name="path">视频处理器ffmpeg.exe的位置</param>
        /// <param name="Parameters">命令参数</param>
        /// <returns>返回执行结果</returns>
        public static string RunProcess(string path,string Parameters)
        {
            //创建一个ProcessStartInfo对象 并设置相关属性
            var oInfo = new ProcessStartInfo(path, Parameters);
            oInfo.UseShellExecute = false;
            oInfo.CreateNoWindow = true;
            oInfo.RedirectStandardOutput = true;
            oInfo.RedirectStandardError = true;
            oInfo.RedirectStandardInput = true;

            //创建一个字符串和StreamReader 用来获取处理结果
            string output = null;
            StreamReader srOutput = null;
            Process proc = null;
            try
            {
                //调用ffmpeg开始处理命令
                proc = Process.Start(oInfo);

                // 可能导致长期等待.
                // proc.WaitForExit();

                //获取输出流
                srOutput = proc.StandardError;

                //转换成string
                output = srOutput.ReadToEnd();

                //关闭处理程序
                proc.WaitForExit(1 * 1000);

                //proc.Close();
            }
            catch (Exception)
            {
                output = string.Empty;
            }
            finally
            {
                //释放资源
                if (srOutput != null)
                {
                    srOutput.Close();
                    srOutput.Dispose();
                }
                //proc.Close();
            }
            return output;
        }

        /// <summary>
        /// 利用ffmpeg获取指定文件的时长，单位:秒;
        /// 调用:var duration = GetDurationByffmpeg(filePath, @"/ffmpeg.exe");
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="ffmpegVirtualPath">ffmpeg.exe的路径</param>
        /// <returns></returns>
        public static int GetDurationByffmpeg(string filePath, string ffmpegPath)
        {
            int duration = 0;
            try
            {
                using (Process pro = new Process())
                {
                    pro.StartInfo.UseShellExecute = false;
                    pro.StartInfo.ErrorDialog = false;
                    pro.StartInfo.RedirectStandardError = true;

                    pro.StartInfo.FileName = ffmpegPath;
                    pro.StartInfo.Arguments = " -i " + filePath;

                    pro.Start();
                    StreamReader errorreader = pro.StandardError;
                    pro.WaitForExit(1 * 1000);

                    string result = errorreader.ReadToEnd();
                    Console.WriteLine(result);
                    if (!string.IsNullOrEmpty(result))
                    {
                        result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length,
                            ("00:00:00").Length);

                        var matchs = Regex.Match(result, @"(\d{2}):(\d{2}):(\d{2})");
                        var hour = Convert.ToInt32(matchs.Groups[1].Value);
                        var minute = Convert.ToInt32(matchs.Groups[2].Value);
                        var second = Convert.ToInt32(matchs.Groups[3].Value);

                        var len = hour * 3600 + minute * 60 + second;
                        duration = len;
                    }
                    return duration;
                }
            }
            catch (Exception)
            {
            }
            return 0;
        }
    }
}
