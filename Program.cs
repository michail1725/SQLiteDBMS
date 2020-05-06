using System;
using System.Windows.Forms;
namespace SQLiteDBMS
{
    static class Program
    {
        public static ApplicationContext Context { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var settings = Properties.Settings.Default;
            if (!settings.greetingNecessity)
            {
                Context = new ApplicationContext(new MainForm());
            }
            else { 
                Context = new ApplicationContext(new GreetingForm());
            }
            Application.Run(Context);
        }
    }
}
