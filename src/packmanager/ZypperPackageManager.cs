namespace PackageManagement
{
    using System.Collections.Generic;
    public class ZypperPackageManager : IPackageManager
    {
        public IList<Package> GetAvailableUpdates()
        {
            var updates = new List<Package>();

            // Refresh the repo
            StartProcess.AndWait("/bin/zypper", "-qn refresh");

            var process = StartProcess.AndWait("/bin/zypper", "-q lu");

            return updates;
        }
    }
}
