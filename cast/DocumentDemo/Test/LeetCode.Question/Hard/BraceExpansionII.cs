using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Question.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/19 星期一 下午 5:28:08
    /// @source : https://leetcode.com/problems/brace-expansion-ii/
    /// @des : 
    /// </summary>
    public class BraceExpansionII
    {
        #region solution

        public IList<string> Solution(string expression)
        {
            ISet<string> res = new HashSet<string>();
            string str = string.Empty;
            bool andFlag = false;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] >= 'a' && expression[i] <= 'z')
                {
                    str += expression[i];
                    continue;
                }

                if (str != string.Empty)
                {
                    res.Add(str);
                    str = string.Empty;
                    andFlag = false;
                }

                if (expression[i] == '{')
                {
                    res = Combination(res, Helper(expression, ref i), andFlag);
                }
                else if (expression[i] == ',')
                {
                    andFlag = true;
                }
            }

            return res.ToList();
        }

        public ISet<string> Helper(string expression, ref int i)
        {
            ISet<string> list = new HashSet<string>();
            string str = string.Empty;
            for (i++; i < expression.Length; i++)
            {
                if (expression[i] >= 'a' && expression[i] <= 'z')
                {
                    str += expression[i];
                    continue;
                }

                if (str != string.Empty)
                {
                    list.Add(str);
                    str = string.Empty;
                }

                if (expression[i] == '}')
                    break;

                if (expression[i] == '{')
                {
                    if (i - 1 > 0)
                    {
                        if (expression[i - 1] == ',')
                        {
                            list = Combination(list, Helper(expression, ref i), true);
                        }
                        else
                        {
                            if (str != string.Empty)
                            {
                                list = Combination(list,
                                    Combination(new HashSet<string>() {str}, Helper(expression, ref i), false), true);
                            }
                        }
                    }
                    else
                    {
                        list = Helper(expression, ref i);
                    }
                }
            }

            return list;
        }

        public ISet<string> Combination(ISet<string> old, ISet<string> next, bool andFlag)
        {
            if (old.Count == 0) return next;
            ISet<string> list;
            if (andFlag)
            {
                list = old;
                foreach (var item in next)
                {
                    list.Add(item);
                }
            }
            else
            {
                list = new HashSet<string>();

                foreach (var a in old)
                {
                    foreach (var b in next)
                    {
                        list.Add(a + b);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}