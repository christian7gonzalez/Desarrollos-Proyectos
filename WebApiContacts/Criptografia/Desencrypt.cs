using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Criptografia
{
    public class Desencrypt
    {
        public string SetDesencrypt(string text)
        {
            string textEncripted = string.Empty;
            Byte[] desencrypt = Convert.FromBase64String(text);
            textEncripted = System.Text.Encoding.Unicode.GetString(desencrypt);
            return textEncripted;
        }
    }
}
