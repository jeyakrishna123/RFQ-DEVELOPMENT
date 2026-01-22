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
                string dirpath = @"C:\Users\Public\Documents\" + "\\LogRFQFlow";
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
                filePath = dirpath + @"\LogRFQFlow.txt";
                
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

                string dirpath = @"C:\Users\Public\Documents\" + "\\LogRFQFlow";
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
                filePath = dirpath + @"\LogRFQGridFlow.txt";

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
