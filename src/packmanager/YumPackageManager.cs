namespace PackageManagement
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class YumPackageManager : IPackageManager
    {
        private YumProcess yumProcess;

        public YumPackageManager()
            : this(new YumProcess())
        {
        }

        public YumPackageManager(YumProcess yumProcess)
        {
            this.yumProcess = yumProcess;
        }

        public IList<Package> GetAvailableUpdates()
        {
            var updates = new List<Package>();

            var packages = new List<string>();
            var reader = this.yumProcess.GetCheckUpdateStreamReader();
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine().TrimStart();
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.ToLower() == "obsoleting packages")
                {
                    break;
                }

                var packageName = line.Substring(0, line.IndexOfAny(new char[]{ ' ', '\t' }));
                packages.Add(packageName);
            }

            // Get details of each package
            foreach(var package in packages)
            {
                var record = this.GetAvailablePackageInfo(package);
                updates.Add(record);
            }

            Trace.TraceInformation("{0} update packages available.", packages.Count);

            return updates;
        }

        public Package GetAvailablePackageInfo(string package)
        {
            var infoReader = this.yumProcess.GetAvailablePackageInfoStreamReader(package);
            var values = infoReader.ToDictionary();

            var name = values["Name"];
            var version = values["Version"];

            var record = new Package
            {
                Name = name,
                Architecture = values["Arch"],
                Version = version,
                Repository = values["Repo"],
            };

            return record;
        }
    }
}
