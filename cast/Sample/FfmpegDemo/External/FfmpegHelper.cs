using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

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

    }
}
