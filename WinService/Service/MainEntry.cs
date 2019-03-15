using System.ServiceProcess;
using System.IO;
using Way2SmsApp.Core;
using Way2SmsApp.Utils;
using System;

namespace Way2SmsApp.WinService
{
    static class MainEntry
    {        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new NodeManager() 
            };

            try
            {
                Initialize();
            }
            catch(Exception ex)
            {
                Logger.LogException(ex);
            }
            
            Logger.LogIt("Starting the service");

            ServiceBase.Run(ServicesToRun);

            //ServiceProcessInstaller bi = new ServiceProcessInstaller();
            //bi.Install(null);
        }

        // Inits the app
        static void Initialize()
        {
            Logger.Initialize(AppConfig.LogsDir, AppConfig.EeventSourceName);
            Logger.LogIt("Initializing the service");
            XmlUtils.Initialize(AppConfig.ManagerXmlsDir);

            // Create greetings dir
            if (!Directory.Exists(AppConfig.GreetingsDir))
            {
                Directory.CreateDirectory(AppConfig.GreetingsDir);
            }
        }
    }
}
