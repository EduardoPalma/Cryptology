using System.Security.Cryptography;
using System.Text;

namespace Encryptor.TripleDes;

public class TripleDes
{
    private string NameFile { get; set;}
    private const string Hash = "9sdfkas 1321_awe";

    public TripleDes(string nameFile)
    {
        NameFile = nameFile;
    }


    public string EncryptorFile()
    {
        var key = Encoding.UTF8.GetBytes(Hash);
        var byteData = File.ReadAllBytes(NameFile);

        var md5 = MD5.Create();
        var desEncryptor = TripleDES.Create();

        desEncryptor.Key = md5.ComputeHash(key);
        desEncryptor.Mode = CipherMode.ECB;

        var transform = desEncryptor.CreateEncryptor();
        var resultEncryptor = transform.TransformFinalBlock(byteData,0, byteData.Length);
        File.WriteAllBytes("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/file.txt",resultEncryptor);
        return Convert.ToBase64String(resultEncryptor);
    }

    public string DesEncryptorFile()
    {
        var key = Encoding.UTF8.GetBytes(Hash);
        var byteData = File.ReadAllBytes("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/file.txt");
        
        var md5 = MD5.Create();
        var desEncryptor = TripleDES.Create();
        
        desEncryptor.Key = md5.ComputeHash(key);
        desEncryptor.Mode = CipherMode.ECB;
        
        var transform = desEncryptor.CreateDecryptor();
        var resulDesEncryptor = transform.TransformFinalBlock(byteData, 0, byteData.Length);
        File.WriteAllText("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/file.txt",Encoding.UTF8.GetString(resulDesEncryptor));
        return Encoding.UTF8.GetString(resulDesEncryptor);
    }

    public static void EncryptorFileVideo(string pathVideo)
    {
        var key = Encoding.UTF8.GetBytes(Hash);
        var byteData =
            File.ReadAllBytes(pathVideo);
        var md5 = MD5.Create();
        var desEncryptor = TripleDES.Create();

        desEncryptor.Key = md5.ComputeHash(key);
        desEncryptor.Mode = CipherMode.ECB;

        var transform = desEncryptor.CreateEncryptor();
        var resultEncryptor = transform.TransformFinalBlock(byteData,0, byteData.Length);
        Stream t = new FileStream("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/videos/video.mp4", FileMode.Create);
        var b = new BinaryWriter(t);
        b.Write(resultEncryptor);
        b.Close();
    }

    public static void DesEncryptorFileVideo(string pathVideoEncrypted)
    {
        var key = Encoding.UTF8.GetBytes(Hash);
        var byteData =
            File.ReadAllBytes(pathVideoEncrypted);
        var md5 = MD5.Create();
        var desEncryptor = TripleDES.Create();

        desEncryptor.Key = md5.ComputeHash(key);
        desEncryptor.Mode = CipherMode.ECB;

        var transform = desEncryptor.CreateDecryptor();
        var resultEncryptor = transform.TransformFinalBlock(byteData,0, byteData.Length);
        Stream t = new FileStream(pathVideoEncrypted, FileMode.Create);
        var b = new BinaryWriter(t);
        b.Write(resultEncryptor);
        b.Close();
    }
}