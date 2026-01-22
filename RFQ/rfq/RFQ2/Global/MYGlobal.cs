using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFQ2.DB;

namespace RFQ2.Global
{
    class MYGlobal
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static String USE_DB = "";

        public static String TYPE_FO = "FO";
        public static String TYPE_PP = "PP";

        // Flag to track if configuration has been loaded
        private static bool _configLoaded = false;

        /// <summary>
        /// Initialize configuration from DIM_RECORDING_USR database
        /// Call this at application startup before any other operations
        /// </summary>
        public static void InitializeConfiguration()
        {
            if (!_configLoaded)
            {
                try
                {
                    log.Info("Initializing configuration from DIM_RECORDING_USR database...");
                    ConfigurationDao.LoadConfiguration();
                    _configLoaded = true;
                    log.Info("Configuration initialized successfully.");
                }
                catch (Exception ex)
                {
                    log.Error("Failed to initialize configuration: " + ex.Message, ex);
                    MessageBox.Show("Failed to load configuration from database.\n" + ex.Message,
                        "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Get configuration value from DIM_RECORDING_USR.Tbl_Configuration
        /// </summary>
        public static string GetConfigValue(string key)
        {
            if (!_configLoaded)
            {
                InitializeConfiguration();
            }
            return ConfigurationDao.GetValue(key);
        }

        /// <summary>
        /// Get configuration value with default
        /// </summary>
        public static string GetConfigValue(string key, string defaultValue)
        {
            if (!_configLoaded)
            {
                InitializeConfiguration();
            }
            return ConfigurationDao.GetValue(key, defaultValue);
        }

        public static string GetSettingValue(string paramName)
        {
            return String.Format(ConfigurationManager.AppSettings[paramName]);
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static String getCString()
        {
            USE_DB = MYGlobal.GetSettingValue("DB");
            log.Info("use_db=" + MYGlobal.USE_DB);
           // var key = "o14ca5898c4e4133bbce2sg2315a2024";
            //var readerstring = string.Empty;

           // string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
           // return connectionString;

            if (MYGlobal.USE_DB.Equals("Local"))
            {
                // live
                string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                return connectionString;
                /*****
                var ConfigPath = ConfigurationManager.AppSettings["ConPathLocal"].ToString();
                using (StreamReader reader = new StreamReader(ConfigPath))
                {
                    string body = reader.ReadToEnd();
                    readerstring = body;
                }
                string decrypted_con = DecryptString(key, readerstring);
                string connectionString = decrypted_con;
                log.Info("connectionString=" + connectionString);
                return connectionString;//@"Data Source=DKTP611587\SQLEXPRESS;Initial Catalog=HalliburtonRFQ;User ID=sa;Password=ABCD7890&*()";
                *****/
               //local
             //return @"Data Source=DESKTOP-SALBO52\MSSQLSERVERD;Initial Catalog=RFQ;User ID=sa;Password=sa123;";
            }
            else if (MYGlobal.USE_DB.Equals("Halliburton"))
            {
                // live
                // return @"Data Source=DKTP611587\SQLEXPRESS;Initial Catalog=HalliburtonRFQ;User ID=sa;Password=ABCD7890&*()";

                //local
                string connectionString = ConfigurationManager.AppSettings["DefaultConnection"].ToString();
                return connectionString;
                /******
                var ConfigPath = ConfigurationManager.AppSettings["ConPathLive"].ToString();
                using (StreamReader reader = new StreamReader(ConfigPath))
                {
                    string body = reader.ReadToEnd();
                    readerstring = body;
                }
                string decrypted_con = DecryptString(key, readerstring);
                string connectionString = decrypted_con;
                log.Info("connectionString=" + connectionString);
                //connectionString = "Server=DESKTOP-SALBO52\\MSSQLSERVERD;Database=RFQ;User Id=sa;Password=sa123;Trusted_Connection=True;Integrated Security=true;";
                return connectionString;
                ********/
                //return @"Data Source=DESKTOP-SALBO52\MSSQLSERVERD;Initial Catalog=RFQ;User ID=sa;Password=sa123;";
            }
                return null;
        }


        public static String getCurretnDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        public static void export2Excel(DataGridView dataGridView, String name)
        {

            DialogResult res = MessageBox.Show("Are you sure to export to Excel ?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.No)
            {
                return;
            }

            if (dataGridView == null)
            {
                return;
            }

            try
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "" + name;
                // storing header part in Excel  
                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        try
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        catch (Exception ee)
                        {
                            log.Error("Error : " + ee.Message);
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                //"c:\\temp\\tpc\\output.xlsx"
                // save the application  
                workbook.SaveAs("c:\\temp\\meie\\" + name + "-" + getCurretnDate() + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  

                //MessageBox.Show("");

                app.Quit();
            }
            catch (Exception ee)
            {
                log.Error("Export Excel Error : " + ee.Message);
                //MessageBox.Show("Export done failed with following error "+ee.Message);
            }

            MessageBox.Show("Export done successfully");
        }

    }
}
