using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Model
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 9:48:43 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class BaseRes<T>
    {
        public int State { get; set; }

        public string Desc { get; set; }

        public T Data { get; set; }

        public bool IsSuccess() => State == 200;

    }

    public class BaseRes : BaseRes<string>
    {

    }
    public class SimpleBaseRes : BaseRes<object>
    {

    }

}
