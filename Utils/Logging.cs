using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Way2SmsApp.Utils
{
    #region LogClass

    public static class Logger
    {
        static Logger()
        {
            
        }

        static bool bInited = false;
        static string _source = "Default: Way2SmsApp ClientService";
        static string _eventBucket = "Application";

        public static void Initialize(string logsPath, string source)
        {
            if (!bInited)
            {
                if (!string.IsNullOrEmpty(source))
                {
                    _source = source;
                }
                StartTracingListener(logsPath);
                bInited = true;
            }
        }

        public static void LogAnEvent(string msg, EventLogEntryType logType = EventLogEntryType.Information)
        {
            if (!EventLog.SourceExists(_source))
            {
                EventLog.CreateEventSource(_source, _eventBucket);
            }

            EventLog eLog = new EventLog();
            eLog.Source = _source;

            eLog.WriteEntry(msg, logType);
        }

        public static void LogAnExceptionEvent(string msg)
        {
            LogAnEvent(msg, EventLogEntryType.Error);
        }

        public static void LogAnExceptionEvent(Exception ex)
        {
            var msg = BuildExceptionMessage(ex);

            LogAnEvent(msg, EventLogEntryType.Error);
        }

        private static void StartTracingListener(string logsPath)
        {
            DirectoryInfo logDirectory = new DirectoryInfo(logsPath);

            if (!logDirectory.Exists)
            {
                logDirectory.Create();
            }

            string logFile = logDirectory.FullName + "\\" + Guid.NewGuid().ToString() + ".txt";

            var logListener = new TextWriterTraceListener(logFile);
            Trace.Listeners.Add(logListener);
            Trace.AutoFlush = true;
        }

        public enum LogSeverity
        {
            Informational,

            Warning,

            Error
        }

        public static void LogIt(string msg, LogSeverity severity = LogSeverity.Informational)
        {
            var logMessage = DateTime.Now + " : " + msg;
            switch (severity)
            {
                case LogSeverity.Informational:
                    Trace.TraceInformation(logMessage);
                    break;

                case LogSeverity.Warning:
                    Trace.TraceWarning(logMessage);
                    break;

                case LogSeverity.Error:
                    Trace.TraceError(logMessage);
                    break;

            }
            Trace.Flush();
        }

        public static void LogException(string msg)
        {
            LogIt(msg, LogSeverity.Error);
        }

        public static void LogException(string msgFormat, object[] msgParams)
        {
            LogIt(string.Format(msgFormat, msgParams), LogSeverity.Error);
        }

        public static void LogException(Exception ex, string customMsg = null, bool bIncludeStackTrace = true)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(customMsg))
            {
                sb.AppendLine("Custom Message: " + customMsg);
            }

            sb.AppendLine(BuildExceptionMessage(ex, bIncludeStackTrace));

            LogIt(sb.ToString(), LogSeverity.Error);
        }

        public static void LogShortException(Exception ex, string customMsg = null)
        {
            LogException(ex, customMsg, false);
        }

        private static string BuildExceptionMessage(Exception ex, bool bIncludeStackTrace = true)
        {
            StringBuilder sb = new StringBuilder("Exception");
            sb.AppendLine("Reason: " + ex.Message);
            
            if (bIncludeStackTrace)
            {
                sb.AppendLine("StackTrace: " + ex.StackTrace);
            }
            
            return sb.ToString();
        }
    }


    #endregion
}
