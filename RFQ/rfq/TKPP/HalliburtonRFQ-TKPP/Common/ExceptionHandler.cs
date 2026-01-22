using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalliburtonRFQ.Common
{
    internal class ExceptionHandler
    {
        public ExceptionHandler() { }
        public  bool Register(Exception e) { 
            if (!Directory.Exists(AppContext.BaseDirectory + "\\ErrorLog"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + "\\ErrorLog");
            }
            string Path = AppContext.BaseDirectory + "\\ErrorLog\\";
            Path = Path + DateTime.Today.ToString("dd-MM-yy") + ".txt";
            var line = Environment.NewLine + Environment.NewLine;
            var trace = new StackTrace(e, true);
            var frame = trace.GetFrames().Last();
            var lineNumber = frame.GetFileLineNumber();
            var fileName = frame.GetFileName();
            string errorName = e.GetType().Name.ToString();
            string errorMsg = e.Message.ToString();

            try
            {
                if (!File.Exists(Path))
                {
                    File.Create(Path).Dispose();
                }
                using (StreamWriter sew = File.AppendText(Path))
                {
                    string error = "Logged At:" + " " + DateTime.Now.ToString() + line;
                    error += "Error:" + " " + errorName + line;
                    error += "Error from :" + " " + fileName;
                    error += " On " + lineNumber + line;
                    error += "Error Message:" + " " + errorMsg + line;
                    sew.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sew.WriteLine("--------------------------------*Start*----------------------------------------");
                    sew.WriteLine(error);
                    sew.WriteLine("--------------------------------*End*------------------------------------------");
                    sew.WriteLine(line);
                    sew.Flush();
                    sew.Close();
                }
                MessageBox.Show("Oops! Something try went wrong.\r\n Kindly Check the Error Log.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show("Oops! Something catch went wrong.\r\n Kindly Check the Error Log.");
            }
            return false;
        }
    }
}
