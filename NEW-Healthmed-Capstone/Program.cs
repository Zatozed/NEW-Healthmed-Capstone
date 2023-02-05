using NEW_Healthmed_Capstone.Inv;
using NEW_Healthmed_Capstone.login;
using System;
using System.Windows.Forms;

namespace NEW_Healthmed_Capstone
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReceivePO());
        }
    }
}
