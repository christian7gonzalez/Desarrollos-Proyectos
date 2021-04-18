using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Criptografia
{
    public class Encrypt
    {
        public string SetEncrypt( string text)
        {
            string textEncripted = string.Empty;
            Byte[] encrypt = System.Text.Encoding.Unicode.GetBytes(text);
            textEncripted = Convert.ToBase64String(encrypt);
            return textEncripted;
        }
    }
}
