namespace HAOS_CMS.Services.Auth;

public interface IEncryptionService
{
    string Encrypt(string plainText, string publicKey);
    string Decrypt(string cipherMessage, string privateKey);
}