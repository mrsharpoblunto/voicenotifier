using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace NotifierWindowsService
{
    [RunInstaller(true)]
    public partial class StartService : Installer
    {
        public StartService()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            ServiceController controller = new ServiceController();
            controller.MachineName = ".";
            controller.ServiceName = "NotifierWindowsService";
            controller.Start();
        }
    }
}
