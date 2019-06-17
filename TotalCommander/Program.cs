using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalCommander.Database;

namespace TotalCommander
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

            IView view = new Form();
            Model model = new Model();

            PresenterView presenterView = new PresenterView(view,model);

            PresenterPane presenterLeftPane = new PresenterPane(view.LeftPane, model);
            PresenterPane presenterRightPane = new PresenterPane(view.RightPane, model);

            Application.Run((Form)view);
        }
    }
}
