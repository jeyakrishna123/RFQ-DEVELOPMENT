using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalliburtonRFQ.Common
{
    public abstract class LogBase
    {
        public readonly object lockObj = new object();
        //  public abstract void CreateLogFile();
        public abstract void Log(string path,string message);
    }

}
