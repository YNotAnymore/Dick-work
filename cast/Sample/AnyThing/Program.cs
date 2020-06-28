using AnyThing.Demo;
using Castle.DynamicProxy;
using Common.CusAttribute;
using Common.Extension;
using Perfolizer.Mathematics.Randomization;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyThing
{

    /// <summary>
    /// 验证码类型
    /// </summary>
    public enum CodeTypes
    {
        /// <summary>
        /// 登录
        /// </summary>
        Login = 1,
        /// <summary>
        /// 注册
        /// </summary>
        Register = 2,
        /// <summary>
        /// 密码修改
        /// </summary>
        ChangePwd = 3

    }

    [Customer]
    public class Program
    {

        public static T GetDefault<T>() => default(T);

        [return: Customer, Description]
        static void Main(string[] args)
        {

            {

                ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost,allowAdmin=true,abortConnect=false,connectTimeout=2000");
                IDatabase database = conn.GetDatabase();

                //string setKey = "anything.test.set";

                //database.SetAdd(setKey, 28394710);

                //RedisValue redisValue = database.SetPop(setKey);
                //RedisValue redisValue2 = database.SetPop(setKey);

                database.KeyDelete("account.valid.code.set");
                database.KeyDelete("account.valid.code.start");

            }

            // byte [0~255]

            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }


    }
}
