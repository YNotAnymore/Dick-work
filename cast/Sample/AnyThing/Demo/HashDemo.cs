using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/29/2020 2:48:22 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class HashDemo
    {

        private const ulong FNV_prime = 1099511628211;

        private const ulong offset_basis = 14695981039346656037;

        /// <summary>
        /// FNV-1 
        /// source:http://www.isthe.com/chongo/tech/comp/fnv/#FNV-param
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ulong FNVH(string str)
        {
            ulong hash_mod = 2 ^ offset_basis;
            ulong hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash = (hash * FNV_prime) % hash_mod;
                hash ^= str[i];
            }

            return hash;
        }

        public static void Run()
        {

            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            CodeTimer codeTimer = new CodeTimer();
            codeTimer.Initialize();

            Dictionary<ulong, string> hashTable = new Dictionary<ulong, string>();

            var time = DateTime.Now;
            //for (int i = 0; i < 10000; i++)
            //{
            //    builder.Append((char)(('a') + random.Next(26)));

            //    var str = builder.ToString();

            //    ulong hash = 0;

            //    CodeTimerResult codeTimerResult = codeTimer.Time(1, () => { hash = FNVH(str); });

            //    Console.WriteLine(codeTimerResult);

            //    hashTable.Add(hash, str);

            //}

            for (int i = 0; i < 10000000; i++)
            {
                var str = Guid.NewGuid().ToString();
                hashTable.Add(FNVH(str), str);
            }

            //Task.WaitAll(tasks);

            //Task[] tasks = new Task[10000000]; 

            //for (int i = 0; i < 10000000; i++)
            //{
            //    tasks[i] = Task.Run(() => {
            //        var str = Guid.NewGuid().ToString();
            //        hashTable.Add(FNVH(str), str);
            //    });
            //    tasks[i].ConfigureAwait(false);
            //}

            //Task.WaitAll(tasks);

            //Parallel.For(0, 1000000, (num) => {
            //    var str = Guid.NewGuid().ToString();
            //    hashTable.Add(FNVH(str), str);
            //});

            var endTime = DateTime.Now;

            Console.WriteLine($"spend:{(endTime - time).TotalMilliseconds}");

        }

    }
}
