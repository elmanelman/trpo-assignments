using System;
using SomeProject.Library.TcpServer;

namespace SomeProject.TcpServer
{
    internal class EnteringPointServer
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        private static void Main()
        {
           try
           {
               var server = new Server();

               server.StartListener().Wait();
           }
           catch(Exception e)
           {
               Console.WriteLine(e.Message);
           }
        }
    }
}
