namespace PackageManagement.Rpm.rpm2gz
{
    using System;
    using System.IO;
    using Library;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1
                || args[0].StartsWith("/")
                || args[0].StartsWith("-"))
            {
                Console.WriteLine("Extracts a gzip archive from a RPM package");
                Console.WriteLine();
                Console.WriteLine("Usage: rpm2gz source");
                return;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            var package = new RpmPackage();
            using (var file = File.Open(filePath, FileMode.Open))
            {
                package = RpmPackage.FromStream(file);
            }

            using (var file = File.Create(package.Lead.Name + ".gz"))
            {
                package.Archive.CopyTo(file);
            }
        }
    }
}
