using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Question.Menu;

namespace LeetCode.Question.CusAttr
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/23 10:55:12
    /// @source : 
    /// @des : 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LevelAttribute:Attribute
    {
        public LevelAttribute(LevelEnum level)
        {
            Level = level;
        }

        public LevelEnum Level { get; }

    }
}
