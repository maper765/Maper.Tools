
namespace Maper.Library.EncryptionsHelpers
{
    public static class EncryptExtension
    {
        public static string CryptRC2(this string value, string key)
            => new RC2().Encrypt(value, key);

        public static string DecryptRC2(this string value, string key)
            => new RC2().Decrypt(value, key);
    }
}
