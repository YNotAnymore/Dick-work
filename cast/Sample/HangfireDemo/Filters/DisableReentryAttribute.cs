using Common.Extension;
using Hangfire;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Server;
using Hangfire.States;
using Hangfire.Storage;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace HangfireDemo.Filters
{
    /// <summary>
    /// 禁用重入执行
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = true)]
    public class DisableReentryAttribute : JobFilterAttribute, IClientFilter, IServerFilter, IElectStateFilter
    {

        /// <summary>
        /// 唯一key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 识别任务是否正在执行
        /// </summary>
        private static ConcurrentDictionary<string, bool> _isRunDic = new ConcurrentDictionary<string, bool>();

        /// <summary>
        /// 创建完成
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnCreated(CreatedContext filterContext)
        {
            Console.WriteLine(nameof(OnCreated));
        }

        /// <summary>
        /// 开始创建
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnCreating(CreatingContext filterContext)
        {
            Console.WriteLine(nameof(OnCreating));
            object v = filterContext.Parameters["Time"];

            if(v is long time)
            {
                DateTime dateTime = DateTimeExt.GetDateTime(time);
                Console.WriteLine($"CreatingContext.Parameters.Time:{dateTime:yyyy-MM-dd HH:mm:ss}");
            }

            string key = GetJobKey(filterContext.Job);
            if (_isRunDic.ContainsKey(key)) // 正在运行
            {
                // 取消执行
                filterContext.Canceled = true;
                return;
            }
        }

        /// <summary>
        /// 执行完成
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnPerformed(PerformedContext filterContext)
        {
            Console.WriteLine(nameof(OnPerformed));
            string key = GetJobKey(filterContext.BackgroundJob.Job);
            _isRunDic.Remove(key, out _);
        }

        /// <summary>
        /// 正在执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnPerforming(PerformingContext filterContext)
        {
            Console.WriteLine(nameof(OnPerforming));
            string key = GetJobKey(filterContext.BackgroundJob.Job);
            if (_isRunDic.ContainsKey(key)) // 正在运行
            {
                // 取消执行
                filterContext.Canceled = true;
                return;
            }
            _isRunDic.AddOrUpdate(key, true, (_, _) => true);
        }

        /// <summary>
        /// 获取任务key
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        private string GetJobKey(Job job)
        {
            return string.IsNullOrEmpty(Key) ? job.Method.DeclaringType.FullName : Key;
        }
        
        /// <summary>
        ///  执行。（异常重试走此通道）
        /// </summary>
        /// <param name="context"></param>
        public void OnStateElection(ElectStateContext context)
        {
            Console.WriteLine(nameof(OnStateElection) + "--" + context.CandidateState);
        }
    }
}
