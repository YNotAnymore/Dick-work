using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AnyThing.Demo
{
    public class GenerateDemo
    {
        /// <summary>
        /// 生成数字和字母
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static string LetterAndNum(int bit)
        {
            using var r = RandomNumberGenerator.Create();

            byte[] arr = new byte[32];
            r.GetBytes(arr);
            StringBuilder codeBuilder = new StringBuilder();
            string code = BitConverter.ToString(arr).Replace("-", "");
            Random r1 = new Random();
            for (int i = 1; i <= bit; i++)
            {
                r1 = new Random(i * r1.Next(bit));
                codeBuilder.Append(code[r1.Next(code.Length - 1)]);
            }
            return codeBuilder.ToString();
        }

        public static string GenerateNumber(string str,int count)
        {

            Random rand = new Random();

            StringBuilder builder = new StringBuilder(count);

            for (int i = 1; i < count; i++)
            {
                builder.Append(str[rand.Next(str.Length)]);
            }
            return builder.ToString();
        }

    }
}
