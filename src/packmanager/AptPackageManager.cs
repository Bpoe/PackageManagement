namespace PackageManagement
{
    using System.Collections.Generic;
    using System.IO;
    
    public class AptPackageManager : IPackageManager
    {
        public IList<Package> GetAvailableUpdates()
        {
            var updates = new List<Package>();

            // Refresh the repo
            //StartProcess.AndWait("/bin/apt-get", "-q update");

            //var process = StartProcess.AndWait("/bin/apt-get", "-s dist-upgrade");

            var fileStream = File.OpenRead("apt-get output.txt");
            var streamReader = new StreamReader(fileStream);
            //while(!process.StandardOutput.EndOfStream)
            while(!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (!line.StartsWith("Inst"))
                {
                    continue;
                }

                // Trim off leading "Inst "
                line = line.Substring(5);
                var packageName = line.Substring(0, line.IndexOf(' '));
            }

            return updates;
        }
    }
}
