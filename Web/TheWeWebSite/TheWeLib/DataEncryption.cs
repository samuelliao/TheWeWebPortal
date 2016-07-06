using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TheWeLib
{
    public class DataEncryption
    {
        public string GetMD5(string inputStr)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            return BitConverter.ToString(b).Replace("-", string.Empty);
        }
    }
}
