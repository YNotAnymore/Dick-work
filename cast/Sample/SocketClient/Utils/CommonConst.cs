﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Utils
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 10:32:52 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class CommonConst
    {
        public static string DomainName = "xxx";
        public static bool IsHttps = true;
        public static string BaseUrl => $"http{(IsHttps ? "s" : "")}://{DomainName}";
        public const string EndCode = "";

    }
}
