using System;
using System.Windows.Forms;

namespace SwordJet
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
                Application.Run(new TournamentManager(args[0]));
            }
            else
            {
                Application.Run(new TournamentManager());
            }
        }
    }
}
