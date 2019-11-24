using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Maper.Library.EncryptionsHelpers
{
    internal class RC2Symetric : IRC2Symetric
    {
        private readonly string _key;
        private readonly string _vectorStart;

        public RC2Symetric(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Encryption key not entered.");

            _key = key;
            _vectorStart = key;
        }

        public string Encrypt(string value)
        {
            using (System.Security.Cryptography.RC2 algorithm = new RC2CryptoServiceProvider())
            {
                using (ICryptoTransform ct = algorithm.CreateEncryptor(Encoding.UTF8.GetBytes(_key)
                    , Encoding.UTF8.GetBytes(_vectorStart)))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            byte[] dados = Encoding.UTF8.GetBytes(value);
                            cs.Write(dados, 0, dados.Length);
                            cs.FlushFinalBlock();

                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
        }

        public string Decrypt(string value)
        {
            using (System.Security.Cryptography.RC2 algorithm = new RC2CryptoServiceProvider())
            {
                using (ICryptoTransform ct = algorithm.CreateDecryptor(Encoding.UTF8.GetBytes(_key)
                    , Encoding.UTF8.GetBytes(_vectorStart)))
                {
                    using (var msDados = new MemoryStream(Convert.FromBase64String(value)))
                    {
                        using (var cs = new CryptoStream(msDados, ct, CryptoStreamMode.Read))
                        {
                            using (var msSaida = new MemoryStream())
                            {
                                using (var sw = new StreamWriter(msSaida))
                                {
                                    sw.Write(new StreamReader(cs).ReadToEnd());
                                }

                                return Encoding.UTF8.GetString(msSaida.ToArray());
                            }
                        }
                    }
                }
            }
        }
    }
}
