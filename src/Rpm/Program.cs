namespace PackageManagement.Rpm
{
    using System;
    using System.IO;

    class Program
    {
        private static ByteConverter converter = new ByteConverter(false);

        static void Main(string[] args)
        {
            var package = new RpmPackage();
            const string FilePath = @"C:\Users\bpoe1\Downloads\rh-dotnet20-dotnet-runtime-2.0-2.0.3-4.1.el7.centos.x86_64.rpm";
            using (var file = File.Open(FilePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(file))
                {
                    package.Lead = RpmLead.FromBinaryReader(reader);
                    package.HeaderStructures[0] = new RpmHeaderStructure
                    {
                        Header = RpmHeaderStructureHeader.FromBinaryReader(reader)
                    };
                    package.HeaderStructures[0].Indexes = new RpmHeaderIndex[package.HeaderStructures[0].Header.IndexCount];
                    for (var x = 0; x < package.HeaderStructures[0].Header.IndexCount; x++)
                    {
                        package.HeaderStructures[0].Indexes[x] = RpmHeaderIndex.FromBinaryReader(reader);
                    }
                }
            }

            Console.WriteLine("Hello World!");
        }
    }

    public class RpmHeaderStructure
    {
        public RpmHeaderStructureHeader Header;

        public RpmHeaderIndex[] Indexes;
    }

    public class RpmPackage
    {
        public RpmLead Lead;

        public RpmHeaderStructure[] HeaderStructures = new RpmHeaderStructure[2];
    }

    public enum PackageType
    {
        Binary = 0,

        Source = 1,
    }

    public enum IndexType
    {
        Null = 0,
        Char = 1, 
        Int8 = 2, 
        Int16 = 3,
        Int32 = 4,
        Int64 = 5,
        String = 6, 
        Bin = 7,
        StringArray = 8,
    }
}
