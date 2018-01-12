namespace PackageManagement.Rpm
{
    using System.IO;

    public class RpmPackage
    {
        public RpmLead Lead;

        public RpmHeaderStructure Signature;

        public RpmHeaderStructure Header;

        public static RpmPackage FromStream(Stream input)
        {
            var package = new RpmPackage
            {
                Lead = RpmLead.FromStream(input),
                Signature = RpmHeaderStructure.FromStream(input),
                Header = RpmHeaderStructure.FromStream(input),
            };

            return package;
        }
    }
}
