using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/19/2020 11:34:39 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class RSAHelper
    {
        public static string RSADecrypt(string privatekey, string content)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] cipherbytes;
                rsa.FromXmlString(privatekey);
                cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
                return Encoding.UTF8.GetString(cipherbytes);
            }
        }
    }
}
