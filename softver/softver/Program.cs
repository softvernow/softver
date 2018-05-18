using softver.Models.Models;
using softver.Models.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace softver.Models
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
            //Application.Run(new MainView());

            MainModel model = new MainModel();
            MainView view = new MainView();

            MainPresenter presenter = new MainPresenter(model, view);
            view.ShowDialog();
            view.Close();
        }
    }
}
