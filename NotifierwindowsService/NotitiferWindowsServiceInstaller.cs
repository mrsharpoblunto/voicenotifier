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
    public partial class NotitiferWindowsServiceInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public NotitiferWindowsServiceInstaller()
        {
            InitializeComponent();

            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "NotifierWindowsService";
            service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
