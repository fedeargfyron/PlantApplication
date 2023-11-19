using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string inputString)
        {
            byte[] data = Encoding.ASCII.GetBytes(inputString);
            data = System.Security.Cryptography.SHA256.HashData(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}
