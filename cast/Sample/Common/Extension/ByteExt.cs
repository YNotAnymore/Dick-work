using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 10:30:07 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class ByteExt
    {

        public static byte[] ByteCut(this byte[] bytes, byte endByte)
        {

            for (int i = bytes.Length - 1; i > 0; i--)
            {
                if (bytes[i] != endByte)
                {
                    var cutBytes = new byte[i + 1];

                    Array.Copy(bytes, cutBytes, i + 1);
                    return cutBytes;
                }
            }

            return Array.Empty<byte>();
        }

    }
}
