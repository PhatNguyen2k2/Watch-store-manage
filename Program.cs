using WatchStoreManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchStoreManage
{
    static class Program
    {
        public static context context = new context();
        public static String connectionString = @"Data Source=FATS\SQLEXPRESS;Initial Catalog=QUANLYCUAHANGDH;Persist Security Info=True;User ID=sa;Password=phat12112002";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new View.viewLogin());
            //Application.Run(new View.viewHomeManager());
            Application.Run(new View.viewHomeStocker());
            //Application.Run(new View.viewHomeStaff());
        }
    }
}
