using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/23/2020 4:01:57 PM
    /// @source : 
    /// @des : number -> [001-999][a-z]*
    /// </summary>
    public class NumberGenerateCodeDemo
    {
        /// <summary>
        /// code生成
        /// YYY...
        ///  1 -> 001
        ///  1000 -> 001a
        ///  当数字超过999时，增加一位小写字母a在后面，再次超过999时，小写字母a变成b直到z，然后再超过就aa，ab...az, 然后就aaa,aab....aaz
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static StringBuilder GetCode(int count)
        {
            if (count <= 999) return ZeroFill(count, 3);

            StringBuilder builder = new StringBuilder();

            builder.Append(ZeroFill((count - 1) % 999 + 1, 3));
            builder.Append(ConvertToLowercase((count - 1) / 999));
            return builder;
        }

        private static StringBuilder ZeroFill(int num, int count)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < count; i++, num /= 10)
            {
                builder.Insert(0, num % 10);
            }

            return builder;
        }

        /// <summary>
        /// number -> 小写字母
        /// 1-26 -> a-z
        /// 27-52 -> aa-az
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static StringBuilder ConvertToLowercase(int num)
        {
            StringBuilder builder = new StringBuilder();
            if (num <= 26)
                builder.Append((char)(((num - 1) % 26) + 'a'));
            else
            {
                builder.Append((char)(((num - 1) % 26) + 'a'));
                while (num >= 26)
                {
                    int prev = num;
                    num /= 26;
                    builder.Insert(0, (char)((num % 26 + (prev % 26 == 0 ? -1 : 0) - 1) + 'a'));
                }
            }
            return builder;
        }
    }
}
