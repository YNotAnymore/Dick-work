using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThing.SpeedTest
{
    public class ForeachTest
    {

        private int[] _source = Enumerable.Range(0, 100000).ToArray();

        [Benchmark]
        public void Normal()
        {
            double[] results = new double[_source.Length];
            for (int i = 0; i < _source.Length; i++)
            {
                results[i] *= Math.PI;
            }
        }

        [Benchmark]
        public void NormalParallel()
        {
            double[] results = new double[_source.Length];

            Parallel.For(0, _source.Length, i => { results[i] = _source[i] * Math.PI; });

        }

        /// <summary>
        /// fastest
        /// </summary>
        [Benchmark]
        public void PartitionerParallel()
        {

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, _source.Length);

            double[] results = new double[_source.Length];

            // Loop over the partitions in parallel.
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = _source[i] * Math.PI;
                }
            });
        }

    }
}
