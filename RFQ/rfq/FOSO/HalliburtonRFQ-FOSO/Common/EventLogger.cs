using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalliburtonRFQ.Common
{
    public class EventLogger : LogBase
    {
     

        public override void Log(string path,string message)
        {
            EventLog eventLog = new EventLog("");
            eventLog.Source = "HaliburtoneventLog";
            eventLog.WriteEntry(message);
        }
    }
}
