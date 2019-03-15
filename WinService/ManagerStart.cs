using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Way2SmsApp.Core;
using Way2SmsApp.Utils;

namespace Way2SmsApp.WinService
{
    //
    // Manager is started by the service once in its OnStart. 
    // After that manager should be doing all the activities
    //
    public class ManagerActivities
    {
        public Thread workerThread;

        bool isRunning = false;

        static string executingExeDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

        // Start command called by the main service
        // It only spawns a worker thread where all the activities will be done
        public void Start()
        {
            workerThread = new Thread(new ThreadStart(WorkerThreadEntry));
            workerThread.IsBackground = true;

            try
            {
                workerThread.Start();
                Logger.LogIt("Started Worker thread");
                isRunning = true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        // Stop command called by the main service
        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                workerThread.Join(1000 * 15);
            }
        }

        //
        // This is the method always running. The core-service activities are here
        // Activities are scheduled by timers, because this is just a keep-alive
        // and it has to respond to shutdowns also in timely manner, therefore it has to have a shorter loop.
        //

        void WorkerThreadEntry()
        {
            //Thread.Sleep(1000 * 30);

            Logger.LogIt("Started worker");

            // Listen for commands

            // Talk to server
            // 1. If self update is available, download it and mark in registry that update is needed.
            // 2. If any other binary update is available, download it and mark in registry
            //    Try to update it at appropriate time
            // 3. Setp a timer on the talker method

            TimeSpan dueTime = new TimeSpan(0, 2, 0);
            TimeSpan period = new TimeSpan(1, 0, 0);
            

            Timer wishTimer = new Timer(SmsSender.SendWishes1, null, dueTime, period);


            // Does Service related work

            while (isRunning)
            {
                // 3 sec sleep at end of loop
                Thread.Sleep(1000 * 10);
            }

            // Worker is stopped, try to cleanup
            Logger.LogIt("Stopped worker");
        }
    }
}
