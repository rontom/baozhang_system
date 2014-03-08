using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace 报障系统
{
    static class Program
    {
        [STAThread]
        static void Main()
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }
}
