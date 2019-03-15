using System.IO;
using System.Xml;

namespace Way2SmsApp.Utils
{
    public static class XmlUtils
    {
        static XmlUtils()
        {

        }
        static bool bInited = false;
        static string _xmlsDir = "Way2SmsApp";

        public static void Initialize(string xmlsPath)
        {
            if (!bInited)
            {
                if (!string.IsNullOrEmpty(xmlsPath))
                {
                    _xmlsDir = xmlsPath;
                }
                bInited = true;
            }
        }

        private static string GetXmlFilePath(NodeXmlTemplateType xmlType)
        {
            var xmlFileName = xmlType.ToString() + ".xml";

            var xmlFilePath = Path.Combine(_xmlsDir, xmlFileName);

            return xmlFilePath;
        }

        public static string GetXmlAsString(NodeXmlTemplateType xmlType)
        {
            var xmlFilePath = GetXmlFilePath(xmlType);

            var xmlContent = File.ReadAllText(xmlFilePath);

            return xmlContent;
        }

        public static XmlDocument GetXmlDocument(NodeXmlTemplateType xmlType)
        {
            var xmlFilePath = GetXmlFilePath(xmlType);

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(xmlFilePath);

            return xmlDoc;
        }
    }

    public enum NodeXmlTemplateType
    {
        PingServerRequest,

        ServerResponseNodeManager,

        ServerResponseCrawler
    }


    public static class FileUtils
    {
        private static void DeleteFileSystemInfo(FileSystemInfo fsi)
        {
            fsi.Attributes = FileAttributes.Normal;
            var di = fsi as DirectoryInfo;

            if (di != null)
            {
                foreach (var dirInfo in di.GetFileSystemInfos())
                    DeleteFileSystemInfo(dirInfo);
            }

            fsi.Delete();
        }


        public static void CopyDirectory(string sourceDir, string destDir)
        {
            if (string.IsNullOrEmpty(sourceDir) || string.IsNullOrEmpty(destDir))
                return;

            CopyDirectory(new DirectoryInfo(sourceDir), new DirectoryInfo(destDir));
        }

        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
            }

            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);

                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
    }
    

    public static class W2SUtils
    {
        public static bool ValidateW2SMobileNumber(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
                return false;

            if (mobile.Length != 10)
                return false;

            long result = 0;
            if (!long.TryParse(mobile, out result))
                return false;

            return true;
        }
    }
}
