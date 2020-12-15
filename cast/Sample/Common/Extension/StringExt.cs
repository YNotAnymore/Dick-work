using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/9/2020 11:21:36 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 去除（...）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveBracket(this string str)
        {
            return Regex.Replace(str, "（[^）]*）", string.Empty);
        }
    }
}
