using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Question.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/16 星期五 下午 5:31:37
    /// @source : https://leetcode.com/problems/parsing-a-boolean-expression/
    /// @des : 
    /// </summary>
    public class ParseBoolExpr
    {
        #region Solution

        public bool Solution(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '!')
                    return HelperNot(ref i, expression);

                if (expression[i] == '&')
                    return HelperAnd(ref i, expression);

                if (expression[i] == '|')
                    return HelperOr(ref i, expression);

                if (expression[i] == 't')
                    return true;
                if (expression[i] == 'f')
                    return false;
            }

            return true;
        }

        public bool HelperNot(ref int start, string expression)
        {
            for (start++; start < expression.Length; start++)
            {
                if (expression[start] == '!')
                    return !HelperNot(ref start, expression);

                if (expression[start] == '&')
                    return !HelperAnd(ref start, expression);

                if (expression[start] == '|')
                    return !HelperOr(ref start, expression);

                if (expression[start] == 't')
                {
                    while (++start < expression.Length && expression[start] != ')') continue;
                    return false;
                }

                if (expression[start] == 'f')
                {
                    while (++start < expression.Length && expression[start] != ')') continue;
                    return true;
                }
            }

            return true;
        }

        public bool HelperAnd(ref int start, string expression)
        {
            var res = true;
            for (start++; start < expression.Length; start++)
            {
                if (expression[start] == '!')
                    res &= HelperNot(ref start, expression);

                else if (expression[start] == '&')
                    res &= HelperAnd(ref start, expression);

                else if (expression[start] == '|')
                    res &= HelperOr(ref start, expression);

                else if (expression[start] == 'f')
                    res = false;

                if (!res)
                {
                    // ReSharper disable once RedundantJumpStatement
                    while (++start < expression.Length && expression[start] != ')') continue;
                    return false;
                }
            }

            return true;
        }

        public bool HelperOr(ref int start, string expression)
        {
            var res = false;
            for (start++; start < expression.Length; start++)
            {
                if (expression[start] == '!')
                    res |= HelperNot(ref start, expression);

                else if (expression[start] == '&')
                    res |= HelperAnd(ref start, expression);

                else if (expression[start] == '|')
                    res |= HelperOr(ref start, expression);

                else if (expression[start] == 't')
                    res = true;

                if (res)
                {
                    while (++start < expression.Length && expression[start] != ')') continue;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region test

        public void Test(Func<string, bool> func)
        {
            Console.WriteLine(func("!(f)") == true);
            Console.WriteLine(func("|(f,t)") == true);
            Console.WriteLine(func("&(t,f)") == false);
            Console.WriteLine(func("|(&(t,f,t),!(t))") == false);
        }

        #endregion
    }
}