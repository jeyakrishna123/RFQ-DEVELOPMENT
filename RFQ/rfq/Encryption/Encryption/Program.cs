using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Encryption
{
    static class Program
    {
        // Define a unique name for the mutex
        static Mutex mutex = new Mutex(true, "Encryption RFQ");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if the application is already running
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("The application is already running.", "Instance Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BringExistingInstanceToFront();
                return; // Exit the new instance
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Release the mutex when the application closes
            mutex.ReleaseMutex();
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private static void BringExistingInstanceToFront()
        {
            // Replace "YourMainFormTitle" with the title of your main form
            IntPtr hWnd = FindWindow(null, "Encrypt the SQL Connection String");

            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
            }
        }

    }
}
