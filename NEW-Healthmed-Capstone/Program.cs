﻿using NEW_Healthmed_Capstone.file_maintenance;
using NEW_Healthmed_Capstone.Inv;
using NEW_Healthmed_Capstone.login;
using NEW_Healthmed_Capstone.Point_of_Sale;
using NEW_Healthmed_Capstone.Reports;
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
            Application.Run(new Form1());
        }
    }
}
