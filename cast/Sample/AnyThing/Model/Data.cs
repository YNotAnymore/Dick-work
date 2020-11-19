using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Model
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 10:18:40 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Data
    {

        public Info Info { get; set; }

    }

    public struct Info
    {
        public bool Flag { get; set; }

        public string Content { get; set; }
    }

}
