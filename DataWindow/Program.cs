using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataWindow
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // create a view
            UsersView view = new UsersView();
            view.Visible = false;
            
            // create Controlker
            UsersController controller = new UsersController(view);
            controller.LoadView();
            view.ShowDialog();
        }
    }
}
