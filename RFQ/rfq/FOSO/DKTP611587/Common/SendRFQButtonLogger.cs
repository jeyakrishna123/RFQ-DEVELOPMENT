using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HalliburtonRFQ.Common
{
  public class SendRFQButtonLogger:LogBase
    {
        StreamWriter sw;

        public override void Log(string path, string message)
        {
            lock (lockObj)
            {
                if (!File.Exists(path))
                {
                 //   sw = File.CreateText(path);
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(message);
                    }
                }
                else
                {
                //    sw = File.AppendText(path);
                  //  sw.WriteLine(message);

                    // Appending the given texts 
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
