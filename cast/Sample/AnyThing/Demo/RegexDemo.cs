using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/20/2020 12:31:00 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class RegexDemo
    {


        /// <summary>
        /// 所有字符.
        /// </summary>
        public const string AllCharPattern = @"\s|\【|\】|\（|\）|\，|\。|\？|\、|\；|\：|\‘|\’|\“|\”|\！|\《|\》|\￥|\……|\——|\/|\~|\!|\@|\#|\\$|\%|\^|\&|\*|\(|\)|_|\+|\{|\}|\:|\<|\>|\?|\[|\]|\,|\.|\/|\;|\'|\`|\-|\=|\\\|\|";
        private static string[] patternArr = new[] {
            @$"[大][{AllCharPattern}]*[区|區]",
        };

        public bool Check(string content)
        {
            foreach (var pattern in patternArr)
            {
                if (Regex.IsMatch(content, pattern))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
