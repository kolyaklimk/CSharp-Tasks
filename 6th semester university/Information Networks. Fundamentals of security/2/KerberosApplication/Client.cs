using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace _2.KerberosApplication
{

    class Client
    {
        public string UserName { get; private set; }
        private string Password { get; set; }

        public string PasswordHash
        {
            get => GetPasswordHash();
        }

        public Client(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string GetPasswordHash()
        {
            var tmpSource = Encoding.ASCII.GetBytes(Password);
            var tmpHash = MD5.HashData(tmpSource);
            var value = new StringBuilder(tmpHash.Length);
            foreach (byte b in tmpHash)
            {
                value.Append(b.ToString("X2"));
            }

            return value.ToString();
        }
    }
}
