namespace PackageManagement
{
    using System.Collections.Generic;
    using System.IO;

    public class PackageManagerDiscoverer
    {
        public IPackageManager Discover()
        {
            if (Platform.IsWindows)
            {
                return new WindowsUpdatePackageManager();
            }

            var packageManagers = new Dictionary<string, IPackageManager>
            {
                { "apt-get", new AptPackageManager() },
                { "zypper", new ZypperPackageManager() },
                { "yum", new YumPackageManager() },
            };

            foreach (var cmd in packageManagers.Keys)
            {
                if (File.Exists("/bin/" + cmd))
                {
                    return packageManagers[cmd];
                }
            }

            return null;
        }
    }
}
