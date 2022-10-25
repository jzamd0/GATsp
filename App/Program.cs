using App.Gui;
using System;
using System.Windows.Forms;

namespace App
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new FrmMain());
            }
            catch (Exception ex)
            {
                var message = $"An error has ocurred and the application crashed.\n{ex.Message}\n{ex.StackTrace}";
                Console.Error.WriteLine(message);
                MessageBox.Show(message, "TSP GA Solver", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
