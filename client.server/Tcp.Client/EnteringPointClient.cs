using System;
using System.Windows.Forms;

namespace SomeProject.TcpClient
{
    internal static class EnteringPointClient
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientMainWindow());
        }
    }
}
