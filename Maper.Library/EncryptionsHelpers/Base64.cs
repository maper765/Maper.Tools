using System;
using System.Text;

namespace Maper.Library.EncryptionsHelpers 
{
    public class Base64 : IBase64
    {
        public string Encrypt(string value)
            => Convert.ToBase64String(Encoding.ASCII.GetBytes(value));

        public string Decrypt(string value)
            => Encoding.ASCII.GetString(Convert.FromBase64String(value));


        public string EncryptUTF8(string value)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        public string DecryptUTF8(string value)
            => Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }
}
