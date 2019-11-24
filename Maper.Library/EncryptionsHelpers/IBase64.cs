
namespace Maper.Library.EncryptionsHelpers
{
    public interface IBase64
    {
        string Encrypt(string texto);

        string Decrypt(string texto);

        string EncryptUTF8(string texto);

        string DecryptUTF8(string texto);
    }
}
