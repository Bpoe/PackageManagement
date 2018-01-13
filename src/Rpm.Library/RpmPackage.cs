namespace PackageManagement.Rpm.Library
{
    using System.IO;

    public class RpmPackage
    {
        public RpmLead Lead;

        public RpmHeaderStructure Signature;

        public RpmHeaderStructure Header;

        public Stream Archive;

        public static RpmPackage FromStream(Stream input)
        {
            var package = new RpmPackage
            {
                Lead = RpmLead.FromStream(input),
                Signature = RpmHeaderStructure.FromStream(input),
                Header = RpmHeaderStructure.FromStream(input),
                Archive = new MemoryStream(),
            };

            input.CopyTo(package.Archive);
            package.Archive.Position = 0;

            return package;
        }
    }
}
