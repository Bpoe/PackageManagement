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
            using (var reader = new BinaryReader2(input, false))
            {
                var header = new RpmHeaderStructureHeader
                {
                    Magic = reader.ReadBytes(3),
                    Version = reader.ReadByte(),
                    Reserved = reader.ReadBytes(4),
                    IndexCount = reader.ReadInt32(),
                    ByteCount = reader.ReadInt32(),
                };

                if (!ArrayCompare.ArrayEquals(header.Magic, MagicBytes))
                {
                    throw new InvalidOperationException("Magic bytes not found in Header Structure Header");
                }

                return header;
            }
        }
    }
}
