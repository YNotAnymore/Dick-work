using Common.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/22/2020 2:14:44 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class LinqProviderDemo
    {

        public void Run()
        {
            #region 从func构建出sql

            string str = new List<Personal>().AsQueryable().SqlWhere(u => u.Age > 10);

            Console.WriteLine(str);

            #endregion
        }


        class Personal
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }

    }
}
