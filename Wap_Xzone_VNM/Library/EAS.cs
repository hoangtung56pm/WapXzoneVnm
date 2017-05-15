using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WapXzone_VNM.Library
{
    public class EAS
    {
        public static string EncryptData(string text, string password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.ECB;

            rijndaelCipher.KeySize = 128;

            rijndaelCipher.BlockSize = 128;

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new byte[16];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = keyBytes;

            ICryptoTransform transform = rijndaelCipher.CreateEncryptor(keyBytes, keyBytes);

            byte[] plainText = Encoding.UTF8.GetBytes(text);

            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);

            return Convert.ToBase64String(cipherBytes);

        }


        public static string DecryptData(string text, string password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Mode = CipherMode.ECB;

            rijndaelCipher.Padding = PaddingMode.None;

            rijndaelCipher.KeySize = 128;

            rijndaelCipher.BlockSize = 128;

            byte[] encryptedData = Convert.FromBase64String(text);

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new byte[16];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);


            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = keyBytes;

            ICryptoTransform transform = rijndaelCipher.CreateDecryptor(keyBytes, keyBytes);

            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);

            string cleartext = Encoding.UTF8.GetString(plainText);
            return cleartext.Replace("\b", "").Replace("\t", "").Replace("\v", "").Replace("\n", "").Replace("\r", "").Replace("\a", "");

        }
    }
}
