using System.IO;
using System.Reflection;

namespace Way2SmsApp.Core
{
    public class AppConfig
    {
        public static string InstallDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        // typeof(TypeInMyModule).Assembly.Location
        // Application.ExecutablePath

        public static string TempFolder = Path.Combine(System.IO.Path.GetTempPath(), @"Way2SmsApp");

        public static string ManagerTempFolder = Path.Combine(TempFolder, @"Manager");

        public static string ManagerDir = InstallDir;

        public static string ManagerXmlsDir = Path.Combine(ManagerDir, @"Xmls");

        public static string LogsDir = Path.Combine(ManagerDir, @"Logs");

        public static string InstallLogsDir = Path.Combine(InstallDir, @"InstallLogs");

        public static string EeventSourceName = "Way2SmsApp Service";

        public static string UdStoreFile = Path.Combine(InstallDir, @"Way2SmsApp.osl");

        public static string AddressBookFile = Path.Combine(InstallDir, @"Way2SmsAddressBook.osl");

        public static string GreetingsDir = Path.Combine(InstallDir, @"GreetingsLog");
    }
}
