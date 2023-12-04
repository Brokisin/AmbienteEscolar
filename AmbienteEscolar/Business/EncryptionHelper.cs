using System;
using System.Security.Cryptography;
using System.Text;

namespace AmbienteEscolar.Business
{
    public class EncryptionHelper
    {
        public static string EncryptString(string plainText, string key = "0123456789ABCDEF")
        {
            byte[] encryptedBytes;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.GenerateIV();
                byte[] ivBytes = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
                byte[] combinedBytes = new byte[ivBytes.Length + encryptedBytes.Length];
                Buffer.BlockCopy(ivBytes, 0, combinedBytes, 0, ivBytes.Length);
                Buffer.BlockCopy(encryptedBytes, 0, combinedBytes, ivBytes.Length, encryptedBytes.Length);

                return BytesToHexString(combinedBytes);
            }
        }

        public static string DecryptString(string encryptedText, string key = "0123456789ABCDEF")
        {
            byte[] encryptedBytes = HexStringToBytes(encryptedText);

            using (Aes aesAlg = Aes.Create())
            {
                int ivSize = aesAlg.BlockSize / 8;
                byte[] ivBytes = new byte[ivSize];
                byte[] encryptedData = new byte[encryptedBytes.Length - ivSize];

                Buffer.BlockCopy(encryptedBytes, 0, ivBytes, 0, ivSize);
                Buffer.BlockCopy(encryptedBytes, ivSize, encryptedData, 0, encryptedData.Length);

                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(encryptedData))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private static byte[] HexStringToBytes(string hexString)
        {
            int byteCount = hexString.Length / 2;
            byte[] bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                bytes[i] = System.Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}
