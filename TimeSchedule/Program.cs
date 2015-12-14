using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TimeSchedule
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

            using (var form = new AutorisationForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(new TimeSchedule());
                }
            }  
        }
    }
}