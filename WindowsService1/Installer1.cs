using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace FolderLoggerService

{
    [RunInstaller(true)]
    public partial class ServiceInstaller : Installer
    {
        public ServiceInstaller()
        {
            InitializeComponent();
            var serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            var processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "Folder logger service";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
