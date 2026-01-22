using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ.Common
{
    public static class Utils
    {
        public static string filePath;
        public static void Log(string message)
        {

            filePath = LogOptions.CreateRFQGridLogFile();
            LogOptions.Log(filePath, LogCategory.OutlookRibbon, message + DateTime.Now);


        }


        public static void showLog(string message)
        {
            // MessageBox.Show(message);
        }

    }
}
