using BenchmarkDotNet.Attributes;
using System;

namespace AnyThing.SpeedTest
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/5/2020 4:41:31 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class ModulusTest
    {

        int[] _arr;

        public ModulusTest()
        {
            var random = new Random();
            _arr = new int[100];

            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = random.Next(1000_000_000 + 1);
            }
        }

        [Benchmark]
        public int Test()
        {
            int zeroNum = 0, oneNum = 0;
            foreach (var item in _arr)
            {
                if (item % 2 == 0) zeroNum++;
                else oneNum++;
            }
            return Math.Min(zeroNum, oneNum);
        }

        [Benchmark]
        public int Test2()
        {
            int zeroNum = 0, oneNum = 0;
            foreach (var item in _arr)
            {
                if (item % 10 % 2 == 0) zeroNum++;
                else oneNum++;
            }
            return Math.Min(zeroNum, oneNum);
        }
    }
}
