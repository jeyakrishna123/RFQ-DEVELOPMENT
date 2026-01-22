using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFQ2.Global;

namespace RFQ2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load configuration from DIM_RECORDING_USR database before starting
            MYGlobal.InitializeConfiguration();

            //Application.Run(new Desktop());
            Application.Run(new Desktop());
        }
    }
}
