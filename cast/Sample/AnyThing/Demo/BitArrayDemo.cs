using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AnyThing.Demo
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/27/2020 2:16:20 PM
    /// @source : 
    /// @des : BitArray 引用类型存储 可用于int列表存储压缩
    /// </summary>
    public class BitArrayDemo
    {

        public void Run()
        {
            int bits;
            string[] binNumber = new string[8];//
            int binary;
            byte[] ByteSet = new byte[] { 1, 2, 3, 4, 5 };//定义一个字节型数组，存5个字节型数值：1,2,3,4,5,6
            BitArray BitSet = new BitArray(ByteSet);//这里一定要注意，这里的每一个字节型数值是以位的形式、每一位用Boolean值、逆序存储在BitArra（1字节对应8位）
            bits = 0;//bits是计数器，到8了就又归为初始值0；为的是方便知道操作完了一个字节型数值（1字节正好占8位）
            binary = 7;//binary是二进制数组下标索引；初始值为7，这是因为BitArray里存储的数据和常规二进制数据的顺序是相反的
            Console.WriteLine("BitSet里包含的元素数" + BitSet.Count);//40，因为数据在BitArray里是以位的形式存储的，5个字节型数值，一个字节占8位所以共占40位！！！不是5！！！
            for (int i = 0; i <= BitSet.Count - 1; i++)//遍历40个位，每个位存boolean值True/False
            {
                Console.WriteLine("BitSet.Get(" + i + ")" + BitSet.Get(i));
                if (BitSet.Get(i) == true)
                    binNumber[binary] = "1";//如果该位存储的true值，则转成1；
                else
                    binNumber[binary] = "0";//如果该位存储的false值，则转成0；
                bits++;      //计数+1
                binary--;    //eg.第8位（下标7）存好，则将下标向左移1位存下一轮将位布尔值转成的二进制0/1

                if ((bits % 8) == 0)//当计数器为8时，表示一个字节型的数值已经表示完全了
                {
                    binary = 7;//将存储字节型数值的二进制形式的String型数组的下标归初始
                    bits = 0;
                    for (int j = 0; j <= 7; j++)
                        Console.Write(binNumber[j]);
                    Console.WriteLine();
                }
            }
        }

    }
}
