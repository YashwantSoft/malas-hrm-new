using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SPApplication.Report;
using SPApplication.Master;
using SPApplication.HR;
using SPApplication.Transaction;
using SPApplication.Views;
 
namespace SPApplication
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
            Application.Run(new LoginWindow());
           // Application.Run(new TestDB());
            //Application.Run(new DailyAttendanceReport());
        }
    }
}
