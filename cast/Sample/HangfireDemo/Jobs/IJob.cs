using HangfireDemo.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Jobs
{
    [DisableReentry]
    public interface IJob
    {

        Task RunAsync();

    }
}
