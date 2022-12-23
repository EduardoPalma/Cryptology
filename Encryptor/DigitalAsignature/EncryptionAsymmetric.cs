using System.Security.Cryptography;

namespace Encryptor.DigitalAsignature;

public static class EncryptionAsymmetric
{
    public static byte[] GenerateSignature(byte [] bytes, RSA rsa)
    {
        //var rsa = RSA.Create();
        //SharedParameters = rsa.ExportParameters(false); //clave publica guardada
        RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);//encripta con la llave privada
        var hash = Authentication.Hash512(bytes);// saco el hash de el archivo
        rsaFormatter.SetHashAlgorithm(nameof(SHA512));// se adapta con que tipo de hash se va a realizar la firma
        return rsaFormatter.CreateSignature(hash);// retorna el hash encriptado
    }

    public static bool VerifySignature(byte [] signedHash, byte [] hash, RSAParameters sharedParameters)
    {
        var rsa = RSA.Create();
        rsa.ImportParameters(sharedParameters);//obtiene la llave publica
        RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
        rsaDeformatter.SetHashAlgorithm(nameof(SHA512));//se adapta con que tipo de hash se va a verificar la firma
        return rsaDeformatter.VerifySignature(hash, signedHash);//retorna si es validado o no
    }
}