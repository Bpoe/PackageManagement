namespace PackageManagement.Rpm
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var package = new RpmPackage();
            const string FilePath = @"C:\Users\bpoe\Downloads\rh-dotnet20-dotnet-runtime-2.0-2.0.3-4.1.el7.centos.x86_64.rpm";
            using (var file = File.Open(FilePath, FileMode.Open))
            {
                package = RpmPackage.FromStream(file);
            }

            Console.WriteLine("Package Lead");
            Console.WriteLine("{0, -15}: {1}", "Major Version", package.Lead.Major);
            Console.WriteLine("{0, -15}: {1}", "Minor Version", package.Lead.Minor);
            Console.WriteLine("{0, -15}: {1}", "Type", package.Lead.Type.ToString());
            Console.WriteLine("{0, -15}: {1}", "Architecture", package.Lead.ArchNum);
            Console.WriteLine("{0, -15}: {1}", "Name", package.Lead.Name);
            Console.WriteLine("{0, -15}: {1}", "OS", package.Lead.OsNum);
            Console.WriteLine("{0, -15}: {1}", "Signature Type", package.Lead.SignatureType);
            Console.WriteLine();
            Console.WriteLine("Package Information");
            Console.WriteLine("{0, -12}: {1}", "Name", package.Header.Tags[(int)Tag.NAME]);
            Console.WriteLine("{0, -12}: {1}", "Version", package.Header.Tags[(int)Tag.VERSION]);
            Console.WriteLine("{0, -12}: {1}", "Release", package.Header.Tags[(int)Tag.RELEASE]);
            Console.WriteLine("{0, -12}: {1}", "Architecture", package.Header.Tags[(int)Tag.ARCH]);
            Console.WriteLine("{0, -12}: {1}", "Group", string.Join(",", package.Header.Tags[(int)Tag.GROUP] as string[]));
            Console.WriteLine("{0, -12}: {1}", "Size", (package.Header.Tags[(int)Tag.SIZE] as int[]).Sum());
            Console.WriteLine("{0, -12}: {1}", "License", package.Header.Tags[(int)Tag.LICENSE]);
            Console.WriteLine("{0, -12}: {1}", "Signature", "");
            Console.WriteLine("{0, -12}: {1}", "Source RPM", package.Header.Tags[(int)Tag.SOURCERPM]);
            Console.WriteLine("{0, -12}: {1}", "Build Date", (package.Header.Tags[(int)Tag.BUILDTIME] as int[])[0]);
            Console.WriteLine("{0, -12}: {1}", "Build Host", package.Header.Tags[(int)Tag.BUILDHOST]);
            Console.WriteLine("{0, -12}: {1}", "Relocations", "");
            Console.WriteLine("{0, -12}: {1}", "Vendor", package.Header.Tags[(int)Tag.VENDOR]);
            Console.WriteLine("{0, -12}: {1}", "Summary", string.Join(",", package.Header.Tags[(int)Tag.SUMMARY] as string[]));
            Console.WriteLine("{0, -12}:", "Description");

            var description = package.Header.Tags[(int)Tag.DESCRIPTION] as string[];
            foreach (var line in description)
            {
                Console.WriteLine(line);
            }
        }
    }
}
