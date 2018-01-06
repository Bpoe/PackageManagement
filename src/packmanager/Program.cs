namespace PackageManagement
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Newtonsoft.Json;

    class Program
    {
        static int Main(string[] args)
        {
            var discoverer = new PackageManagerDiscoverer();
            var packageManager = discoverer.Discover();
            //var packageManager = new AptPackageManager();

            if (packageManager == null)
            {
                Trace.TraceError("Unable to find a supported package manager.");
                Console.WriteLine("ERROR: Unable to find a supported package manager.");
                return -1;
            }

            var packages = packageManager.GetAvailableUpdates();
            
            if (packages == null || packages.Count == 0)
            {
                Console.WriteLine("No packages found.");
                return 1;
            }

            Console.WriteLine(string.Format("{0} {1} {2}",
                "Name",
                "Version",
                "Architecture"));
            foreach(var package in packages)
            {
                Console.WriteLine(string.Format(
                    "{0} {1} {2}",
                    package.Name,
                    package.Version,
                    package.Architecture));
            }

            return 0;
        }
    }
}
