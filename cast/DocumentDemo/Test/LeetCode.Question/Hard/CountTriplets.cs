using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Question.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/22 11:00:31
    /// @source : https://leetcode.com/problems/triples-with-bitwise-and-equal-to-zero/
    /// @des : 
    /// </summary>
    public class CountTriplets
    {
        public int Solution(int[] arr)
        {
            var res = 0;

            if (arr.Length < 3) return res;

            var len = arr.Length;
            
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if ((arr[i] & arr[j] & arr[k]) == 0) res++;
                    }
                }
            }
            
            return res;
        }
    }
}