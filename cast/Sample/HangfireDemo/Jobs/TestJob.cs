using HangfireDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    [DisableReentry]
    public class TestJob
    {

        public async Task Run()
        {

            Console.WriteLine($"开始执行：{DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            var rand = new Random();

            if(rand.Next(2) == 1)
            {
                throw new Exception("test error");
            }

            // 模拟耗时
            await Task.Delay(5 * 1000);

            Console.WriteLine($"执行完毕：{DateTime.Now:yyyy-MM-dd HH:mm:ss}");

        }

    }
}
