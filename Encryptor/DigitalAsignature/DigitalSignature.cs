using System.Security.Cryptography;

namespace Encryptor.DigitalAsignature;

public class DigitalSignature
{
    private RSAParameters SharedParameters { get; }
    private RSA Rsa { get;}

    public DigitalSignature()
    {
        Rsa = RSA.Create();
        SharedParameters = Rsa.ExportParameters(false);
    }

    public byte[] GenerateSignature(string path)
    {
        var bytes = File.ReadAllBytes(path);
        return EncryptionAsymmetric.GenerateSignature(bytes,Rsa);
    }

    public bool VerificySignature(string path, byte[] signature)
    {
        var bytes = File.ReadAllBytes(path);
        var hash = Authentication.Hash512(bytes);
        return EncryptionAsymmetric.VerifySignature(signature,hash,SharedParameters);
    }
}