// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using Encryptor.AES;
using Encryptor.DigitalAsignature;


void EncriptedFiles(string path)
{
    var files = Directory.GetFiles(path, "*");
    foreach (var file in files)
    {
        AesEncryptor.Encrypt(file);
    }
}

void DescriptedFiles(string path)
{
    var files = Directory.GetFiles(path, "*");
    foreach (var file in files)
    {
        AesEncryptor.Decrypt(file);
    }
}
var datos = Environment.GetCommandLineArgs();
try
{
    switch (datos[1])
    {
        case "-rom":
            switch (datos[2])
            {
                case "-e":
                    EncriptedFiles(datos[3]);
                    break;
                case "-d":
                    DescriptedFiles(datos[3]);
                    break;
            }
            break;
    }
}
catch (Exception e)
{
    Console.WriteLine("Error de comandos, ejecute nuevamente");
}

//AesEncryptor.Encrypt("C:/Users/Hello/RiderProjects/Encryptor/Encryptor/videos/video.mp4");
//AesEncryptor.Decrypt("C:/Users/Hello/RiderProjects/Encryptor/Encryptor/videos/video.mp4");