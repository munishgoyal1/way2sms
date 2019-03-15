using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Way2SmsApp.Core;
using Way2SmsApp.Utils;

namespace Way2SmsApp.WinService
{
    [RunInstaller(true)]
    public partial class ServiceProcessInstaller : System.Configuration.Install.Installer
    {
        public ServiceProcessInstaller()
        {
            InitializeComponent();
        }

    

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary savedState)
        {
            //Thread.Sleep(1000 * 60 * 1);
            // Install binaries
            base.Install(savedState);

            try
            {
                Logger.LogAnEvent("Trying to install and start service");
                //Debugger.Break();
                //ServiceController controller = new ServiceController("NodeManager");
                //controller.Start();
                //Installs and starts the service
                //ServiceInstaller.InstallAndStart(NodeManager.SERVICE_NAME, NodeManager.SERVICE_DISPLAYNAME, @"C:\Program Files (x86)\Microsoft\NodeSetup\NodeService.exe");
                ServiceInstaller.StartService(NodeManager.SERVICE_NAME);
            }
            catch (Exception ex)
            {
                Logger.LogAnEvent(@"The service could not be started. Please start the service manually. Error: " + ex.Message, EventLogEntryType.Error);

            }
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            Logger.LogAnEvent("Commit");
            base.Commit(savedState);
            //System.Diagnostics.Process.Start("notepad.exe");
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            Logger.LogAnEvent("RollBack");
            // Check if service is installed
            //if (ServiceInstaller.ServiceIsInstalled(NodeManager.SERVICE_NAME))
            //{
            //    // First Remove the service
            //    ServiceInstaller.Uninstall(NodeManager.SERVICE_NAME);
            //}

            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            Logger.LogAnEvent("Uninstall");
            //Thread.Sleep(1000 * 60 * 1);
            //Debugger.Break();

            try
            {
                // Remove binaries
                base.Uninstall(savedState);

                // catch any exceptions and try to do clean uninstall yourself here
                // Check if service is installed
                //if (ServiceInstaller.ServiceIsInstalled(NodeManager.SERVICE_NAME))
                //{
                //    // First Remove the service
                //    ServiceInstaller.Uninstall(NodeManager.SERVICE_NAME);
                //}

                // Let the service do its cleanup and stop, give it some time

                Thread.Sleep(1000 * 5);

            
                // May be save the logs
                FileUtils.CopyDirectory(AppConfig.LogsDir, AppConfig.ManagerTempFolder);

                if (Directory.Exists(AppConfig.ManagerDir))
                {
                    Directory.Delete(AppConfig.ManagerDir, true);
                }

                FileUtils.CopyDirectory(AppConfig.ManagerTempFolder, AppConfig.LogsDir);

                Directory.Delete(AppConfig.ManagerTempFolder, true);
            }
            catch (Exception ex)
            {
                Logger.LogAnExceptionEvent(ex);
            }
        }
    }
}
