using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using NotifierService;

namespace NotifierWindowsService
{
    public partial class NotifierWindowsService : ServiceBase
    {
        private NotifierHttpServer _server;

        public NotifierWindowsService()
        {
            InitializeComponent();
            _server = new NotifierHttpServer(int.Parse(ConfigurationManager.AppSettings["port"]));

        }

        protected override void OnStart(string[] args)
        {
            _server.Start();
        }

        protected override void OnStop()
        {
            _server.Stop();
        }
    }
}
