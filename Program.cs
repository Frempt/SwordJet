using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TournamentGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 0)
            {
                Logging.WriteToLog("DebugLog", args[0]);
                MessageBox.Show(args[0]);
                Application.Run(new TournamentManager(args[0]));
            }
            else
            {
                Logging.WriteToLog("DebugLog", "No args passed");
                MessageBox.Show("No args");
                Application.Run(new TournamentManager());
            }
        }
    }
}
