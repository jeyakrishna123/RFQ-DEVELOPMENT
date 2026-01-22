using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalliburtonRFQ.Common
{
    public class OutlookRibbonLogger : LogBase
    {
        StreamWriter sw;
        public override void Log(string path,string message)
        {
            lock (lockObj)
            {
                if (!File.Exists(path))
                {
                   // sw = File.CreateText(path);
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(message);
                    }
                }
                else
                {
                   // sw = File.AppendText(path);
                   // sw.WriteLine(message);
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(message);
                    }
                }
                //using (StreamWriter streamWriter = new StreamWriter(path))
                //{
                //    streamWriter.WriteLine(message);
                //    streamWriter.Close();
                //}
            }
        }
    }

}
