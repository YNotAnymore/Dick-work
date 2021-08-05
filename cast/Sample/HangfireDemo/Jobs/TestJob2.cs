using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    public class TestJob2 : IJob
    {
        public async Task RunAsync()
        {
            Console.WriteLine($"开始执行：{DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            // 模拟耗时
            await Task.Delay(10 * 1000);

            Console.WriteLine($"执行完毕：{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
