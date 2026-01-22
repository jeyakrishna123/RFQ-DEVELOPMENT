using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalliburtonRFQ.Common
{
    public static class LogOptions
    {
        private static LogBase logger = null;
        public static string filePath;
        public static readonly object lockObj = new object();
        public static StreamWriter sw;
        public static void Log(string path,LogCategory category, string message)
        {
            switch (category)
            {
                case LogCategory.OutlookRibbon:
                    logger = new OutlookRibbonLogger();
                 
                    logger.Log(path,message);
                    break;
                case LogCategory.SendRFQButton:
                    logger = new SendRFQButtonLogger();

                    logger.Log(path, message);
                    break;
                case LogCategory.EventLog:
                    logger = new EventLogger();
                    logger.Log(path, message);
                    break;
                default:
                    return;
            }
        }

        public static string CreateLogFile()
        {
            lock (lockObj)
            {
                // Extract the drive letter of the application
                string LogFolder = "LogRFQTKPPFlow";
                string LogFile = "RFQFlow-TKPP.txt";
                string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string winstallDrive = Path.GetPathRoot(MyDocuments);
                // Construct the desired log path dynamically
                string dirpath = Path.Combine(winstallDrive, "Users", "Public", "Documents", LogFolder);
                /* string dirpath = @"C:\Users\Public\Documents\" + "\\LogRFQTKPPFlow";
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }*/
                // Check if the constructed path exists
                if (!Directory.Exists(dirpath))
                {
                    try
                    {
                        Directory.CreateDirectory(dirpath);
                    }
                    catch (Exception ex)
                    {
                        // Fallback to a known path if the constructed path doesn't exist
                        dirpath = Path.Combine(MyDocuments, LogFolder);
                        if (!Directory.Exists(dirpath))
                        {
                            Directory.CreateDirectory(dirpath);
                        }
                    }
                }

                // filePath = dirpath + @"\LogRFQFlow.txt";
                string fileDate = DateTime.Today.ToString("dd-MM-yyyy");
                string extension = Path.GetExtension(LogFile);
                FileInfo Fileinfo = new FileInfo(LogFile);
                string fileName = Path.GetFileNameWithoutExtension(Fileinfo.Name);
                LogFile = $"{fileName}-{fileDate}{Fileinfo.Extension}";
                filePath = Path.Combine(dirpath, LogFile);

                //if (!File.Exists(filePath))
                //{
                //    sw = File.CreateText(filePath);                   
                //}
                //else
                //{
                //    //sw = File.AppendText(filePath);
                //    using (var stream = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                //    {
                //    }
                //}
                return filePath;
            }
        }

        public static string CreateRFQGridLogFile()
        {
            lock (lockObj)
            {
                // Extract the drive letter of the application
                string LogFolder = "LogRFQTKPPFlow";
                string LogFile = "GridFlow-TKPP.txt";
                string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string winstallDrive = Path.GetPathRoot(MyDocuments);
                // Construct the desired log path dynamically
                string dirpath = Path.Combine(winstallDrive, "Users", "Public", "Documents", LogFolder);
                //string dirpath = @"C:\Users\Public\Documents\" + "\\LogRFQTKPPFlow";
                if (!Directory.Exists(dirpath))
                {
                    try
                    {
                        Directory.CreateDirectory(dirpath);
                    }
                    catch (Exception ex)
                    {
                        // Fallback to a known path if the constructed path doesn't exist
                        dirpath = Path.Combine(MyDocuments, LogFolder);
                        if (!Directory.Exists(dirpath))
                        {
                            Directory.CreateDirectory(dirpath);
                        }
                    }
                }
                filePath = dirpath + @"\LogRFQGridFlow.txt";
                string fileDate = DateTime.Today.ToString("dd-MM-yyyy");
                string extension = Path.GetExtension(LogFile);
                FileInfo Fileinfo = new FileInfo(LogFile);
                string fileName = Path.GetFileNameWithoutExtension(Fileinfo.Name);
                LogFile = $"{fileName}-{fileDate}{Fileinfo.Extension}";
                filePath = Path.Combine(dirpath, LogFile);
                //MessageBox.Show(filepath);
                //if (!File.Exists(filePath))
                //{
                //    sw = File.CreateText(filePath);                  
                //}
                //else
                //{
                //   // sw = File.AppendText(filePath);
                //    using (var stream = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                //    {
                //    }
                //}
                return filePath;
            }
        }
    }
}
