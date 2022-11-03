// See https://aka.ms/new-console-template for more information


using System.Security.Cryptography;
using System.Text;
using Encryptor.AES;
using Encryptor.TripleDes;
/*
var tDes = new TripleDes("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/files/17 LEYES DEL TRABAJO EN EQUIPO.txt");
//var encryptor = tDes.EncryptorFile();
//var desencryptor = tDes.DesEncryptorFile();
//TripleDes.EncryptorFileVideo("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/videos/Imagine for 1 Minute.mp4");
TripleDes.DesEncryptorFileVideo("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/videos/video.mp4");
*/
//AesEncryptor.Encrypt("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/videos/video.mp4");
AesEncryptor.Decrypt("C:/Users/Eduardo/RiderProjects/Encryptor/Encryptor/videos/video.mp4",Format.Video);