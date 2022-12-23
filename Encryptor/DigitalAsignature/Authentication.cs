using System.Security.Cryptography;

namespace Encryptor.DigitalAsignature;

public static class Authentication
{
    public static byte[] Hash512(byte [] bytes)
    {
        var hash = SHA512.Create();
        return hash.ComputeHash(bytes);

    }
}