using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Way2SmsApp.Utils;

namespace Way2SmsApp.WinService
{
    public partial class NodeManager : ServiceBase
    {
        public static readonly string SERVICE_NAME = "Way2SmsAppManager";

        public static readonly string SERVICE_DISPLAYNAME = "Way2SmsApp";

        public static readonly string SERVICE_DESCRIPTION = "Way2Sms Birthday Wish Service";

        public static readonly bool SERVICE_DELAYEDAUTOSTART = false;

        ManagerActivities manager = new ManagerActivities();

        //Thread t;

        //bool isRunning = false;

        public NodeManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //isRunning = true;

            base.OnStart(args);

            manager.Start();

            Logger.LogIt("Started Manager Service");
            //t = new Thread(new ThreadStart(manager.Start));
            //t.Start();
        }

        protected override void OnStop()
        {
            base.OnStop();

            manager.Stop();

            Logger.LogIt("Stopped Manager Service");
            //t.Join(1000 * 5);

            //isRunning = false;
        }

    }
}
