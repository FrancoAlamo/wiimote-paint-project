﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PaintProgram
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

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Caught exception #1.", e);
            }

        }
    }
}
