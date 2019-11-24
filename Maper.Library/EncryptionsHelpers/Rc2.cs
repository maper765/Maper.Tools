
namespace Maper.Library.EncryptionsHelpers
{ 
    public class RC2 
    {
        public string Encrypt(string value, string key)
        {
            return new RC2Symetric(key).Encrypt(value);
        }

        public string Decrypt(string value, string key)
        {
            return new RC2Symetric(key).Decrypt(value);
        }
    }
}
