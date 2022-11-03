
using System.Security.Cryptography;
using System.Text;

namespace Encryptor.AES;

public static class AesEncryptor
{
    private const string Pw = "9aad9fjjasdk1ad131a@";

    public static void Encrypt(string filePath)
    {
        var bytes = File.ReadAllBytes(filePath);
        var passwordByte = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(Pw));
        var dataEncrypt = Encrypt(bytes, passwordByte);
        File.WriteAllBytes(filePath,dataEncrypt);
    }

    public static void Decrypt(string filePath,Format u = Format.Txt)
    {
        var bytes = File.ReadAllBytes(filePath);
        var passwordByte = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(Pw));
        var dataDecrypt = Decrypt(bytes,passwordByte);
        if (Format.Video == u)
        {
            Stream t = new FileStream(filePath, FileMode.Create);
            var b = new BinaryWriter(t);
            b.Write(dataDecrypt);
            b.Close();
        }
        else File.WriteAllText(filePath,Encoding.UTF8.GetString(dataDecrypt));
    }

    private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
    {
        var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using var ms = new MemoryStream();
        using var aes = Aes.Create();
        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);

        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
            cs.Close();
        }

        var encryptedBytes = ms.ToArray();

        return encryptedBytes;
    }

    private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes) 
    { 
        var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        using var ms = new MemoryStream();
        using var aes = Aes.Create();
        var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Key = key.GetBytes(aes.KeySize / 8);
        aes.IV = key.GetBytes(aes.BlockSize / 8);
        aes.Mode = CipherMode.CBC;

        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
        {
            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
            cs.Close();
        }
        var decryptedBytes = ms.ToArray();

        return decryptedBytes;
    }
}

public enum Format
{
    Txt = 1,
    Video = 2
}