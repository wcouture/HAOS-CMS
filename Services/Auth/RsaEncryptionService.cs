using System.Security.Cryptography;
using System.Text;

namespace HAOS_CMS.Services.Auth;

public class RsaEncryptionService : IEncryptionService
{

    public RsaEncryptionService() {}
    public string Decrypt(string cipherMessage, string privateKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.FromXmlString(privateKey);
            byte[] cipherBytes = Convert.FromBase64String(cipherMessage);
            byte[] decryptedBytes = rsa.Decrypt(cipherBytes, RSAEncryptionPadding.Pkcs1);
            string decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedMessage;
        }
    }

    public string Encrypt(string plainText, string publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.FromXmlString(publicKey);
            byte[] messageBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1);
            string encryptedMessage = Convert.ToBase64String(encryptedBytes);
            return encryptedMessage;
        }
    }
}