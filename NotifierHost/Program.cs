using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using NotifierService;

namespace NotifierHost
{
    class Program
    {
        static void Main(string[] args)
        {
            NotifierHttpServer server = new NotifierHttpServer(int.Parse(ConfigurationManager.AppSettings["port"]));
            server.Start();
        }
    }
}
