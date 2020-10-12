using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extension
{
    public static class NumberExt
    {
        /// <summary>
        /// number -> 小写字母
        /// 1-26 -> a-z
        /// 27-52 -> aa-az
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ConvertToLowercase(this int num)
        {
            StringBuilder builder = new StringBuilder();

            while (num > 0)
            {
                builder.Insert(0, (char)(((num - 1) % 26) + 'a'));
                num = (num - 1) / 26;
            }

            //if (num < 26)
            //    builder.Append((char)(((num - 1) % 26) + 'a'));
            //else
            //{
            //    builder.Append((char)(((num - 1) % 26) + 'a'));
            //    while (num > 26)
            //    {
            //        int prev = num;
            //        num /= 26;
            //        builder.Insert(0, (char)((num % 26 + (prev % 26 == 0 ? -1 : 0)) + 'a'));
            //    }
            //}
            return builder.ToString();
        }

        public static int ConvertToNumber(this string str)
        {
            int num = 0;
            foreach (var c in str)
            {
                num = num * 26 + (c - 'a' + 1);
            }
            return num;
        }

    }
}
