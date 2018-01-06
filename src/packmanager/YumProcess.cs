namespace PackageManagement
{
    using System.IO;
    
    public class YumProcess
    {
        public StreamReader GetCheckUpdateStreamReader()
        {
            var process = StartProcess.AndWait("/bin/yum", "check-update"); // "list update"?
            return process.StandardOutput;
        }

        public StreamReader GetAvailablePackageInfoStreamReader(string package)
        {
            var infoProcess = StartProcess.AndWait("/bin/yum", "info available " + package);
            return infoProcess.StandardOutput;
        }
    }
}
