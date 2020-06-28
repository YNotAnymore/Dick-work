using Autofac;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSample.MsgHandle
{
    public class TestHandler: ICapSubscribe
    {
        private readonly IWork work;

        public TestHandler(IWork work,ILifetimeScope lifetimeScope)
        {

            this.work = work;
            work.Run();
        }

        [CapSubscribe("test.fun")]
        public void Run(string msg)
        {
            Console.WriteLine($"receive msg : {msg}");
        }

    }

}
