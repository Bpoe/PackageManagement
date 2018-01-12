namespace PackageManagement.Rpm
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var package = new RpmPackage();
            const string FilePath = @"C:\Users\bpoe1\Downloads\rh-dotnet20-dotnet-runtime-2.0-2.0.3-4.1.el7.centos.x86_64.rpm";
            using (var file = File.Open(FilePath, FileMode.Open))
            {
                package = RpmPackage.FromStream(file);
            }

            Console.WriteLine("Major Version  : {0}", package.Lead.Major);
            Console.WriteLine("Minor Version  : {0}", package.Lead.Minor);
            Console.WriteLine("Type           : {0}", package.Lead.Type.ToString());
            Console.WriteLine("Architecture   : {0}", package.Lead.ArchNum);
            Console.WriteLine("Name           : {0}", package.Lead.Name);
            Console.WriteLine("OS             : {0}", package.Lead.OsNum);
            Console.WriteLine("Signature Type : {0}", package.Lead.SignatureType);
        }
    }
}
