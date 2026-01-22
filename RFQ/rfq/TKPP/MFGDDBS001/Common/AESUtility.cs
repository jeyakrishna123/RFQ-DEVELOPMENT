using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace HalliburtonRFQ.Common
{
    public class AESUtility
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("o14ca5898c4e4133bbce2sg2315a2024"); // 16 bytes key for AES-128
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("THIS IS MYIV4321"); // 16 bytes IV
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string ConnectionString()
        {
            string connectionString = string.Empty;
            try
            {
                var readerstring = string.Empty;
                string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string winstallDrive = Path.GetPathRoot(MyDocuments);
                // Construct the desired log path dynamically
                string dirpath = Path.Combine(winstallDrive, "Users", "Public", "Documents", "RFQGCDATA");
                string filePath = Path.Combine(dirpath, "SystemConfig.RFQTKPP.txt");
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);           
                    if (!File.Exists(filePath))
                    {
                        using (FileStream fs = File.Create(filePath))
                        {
                            // File is created and can be written to here
                           
                        } // FileStream is disposed here
                    }
                }
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string body = reader.ReadToEnd();
                    readerstring = body;
                }
                //string plainText = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                connectionString = AESUtility.Decrypt(readerstring).ToString();
                connectionString = $"{connectionString}";
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
            }
            return connectionString;
        }
        // Encrypt a string using AES
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(
                        memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        // Decrypt a string using AES
        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(
                        memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}
