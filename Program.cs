using System;
using System.Threading;
using System.Windows.Forms;

namespace DEVEL101
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using var mutex = new Mutex(true, "The101Box_SingleInstance", out bool isNew);
            if (!isNew)
            {
                MessageBox.Show("The101Box is already running.", "Already running",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
