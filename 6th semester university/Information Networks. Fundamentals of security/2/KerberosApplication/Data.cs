using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.KerberosApplication
{
    public class TGT
    {
        public string c;
        public string tgs;
        public string t1;
        public string p1;
        public string K_C_TGS;
    }

    public class KDC
    {
        public string KC;
        public string K_AS_TGS;
    }

    public static class Methods
    {
        static public string GenerateRandomString(int length)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[random.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}