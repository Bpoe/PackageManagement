namespace PackageManagement.Rpm.Library
{
    using System;
    using System.IO;

    public class RpmHeaderStructureHeader
    {
        public static readonly byte[] MagicBytes = { 0x8e, 0xad, 0xe8 };

        // 3 bytes
        public byte[] Magic;

        public byte Version;

        // 4 bytes
        public byte[] Reserved;

        public int IndexCount;

        public int ByteCount;

        public static RpmHeaderStructureHeader FromStream(Stream input)
        {
            var header = new RpmHeaderStructureHeader();
            using (var reader = new BinaryReader2(input, false))
            {
                header.Magic = reader.ReadBytes(3);
                header.Version = reader.ReadByte();
                header.Reserved = reader.ReadBytes(4);
                header.IndexCount = reader.ReadInt32();
                header.ByteCount = reader.ReadInt32();
            }

            if (!ArrayCompare.ArrayEquals(header.Magic, MagicBytes))
            {
                throw new InvalidOperationException("Magic bytes not found in Header Structure Header");
            }

            return header;
        }
    }
}
