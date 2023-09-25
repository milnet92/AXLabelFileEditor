using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AXLabelFileEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            LabelFile labelFile = null;

            if (args.Length > 0)
            {
                labelFile = new LabelFile(args[0]);
            }
            else
            {
                MessageBox.Show("No label file was specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LabelEditor(labelFile));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
