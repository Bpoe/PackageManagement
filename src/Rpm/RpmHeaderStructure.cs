namespace PackageManagement.Rpm
{
    using System.IO;

    public class RpmHeaderStructure
    {
        public RpmHeaderStructureHeader Header;

        public RpmHeaderIndex[] Indexes;

        public static RpmHeaderStructure FromStream(Stream input)
        {
            var header = new RpmHeaderStructure();
            header.Header = RpmHeaderStructureHeader.FromStream(input);
            header.Indexes = new RpmHeaderIndex[header.Header.IndexCount];

            for (var x = 0; x < header.Header.IndexCount; x++)
            {
                header.Indexes[x] = RpmHeaderIndex.FromStream(input);
            }

            var store = new byte[header.Header.ByteCount];
            var bytesRead = input.Read(store, 0, header.Header.ByteCount);

            // read past null padding
            var remaining = bytesRead % 8;
            for (var x = 0; x < remaining; x++)
            {
                input.ReadByte();
            }

            return header;
        }
    }
}
