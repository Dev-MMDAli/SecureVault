using System.Security.Cryptography;
using System.Text;

namespace SecureVault.Services
{
    public class EncryptionService
    {
        readonly private byte[] _key;
        readonly private byte[] _iv;
       public EncryptionService(string KEY, string IV)
       {
           _key = Encoding.UTF8.GetBytes(KEY);
           _iv = Encoding.UTF8.GetBytes(IV);
       }

       public string Encrypt(string plainText)
       {
           using (Aes aes=Aes.Create())
           {
               aes.Key = _key;
               aes.IV = _iv;
               
               ICryptoTransform encryptor= aes.CreateEncryptor(aes.Key,aes.IV);

               using (MemoryStream ms = new MemoryStream())
               {

                   using(CryptoStream cs =new CryptoStream(ms,encryptor,CryptoStreamMode.Write))
                   {
                       using (StreamWriter sw = new StreamWriter(cs))
                       {
                           sw.Write(plainText);
                       }
                   }

                   return Convert.ToBase64String(ms.ToArray());
               }

            }

       }

       public string Decrypt(string cipherText)
       {
           byte[] buffer = Convert.FromBase64String(cipherText);

           using (Aes aes=Aes.Create())
           {
               aes.Key= _key;
               aes.IV= _iv;

               ICryptoTransform decryptor= aes.CreateDecryptor(aes.Key,aes.IV);

               using (MemoryStream ms =new MemoryStream(buffer))
               {
                   using (CryptoStream cs = new CryptoStream(ms,decryptor,CryptoStreamMode.Read))
                   {
                       using (StreamReader sr=new StreamReader(cs))
                       {
                           return sr.ReadToEnd();
                       }
                   }
               }

           }
       }
    }
}
