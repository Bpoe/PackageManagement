namespace PackageManagement.Rpm
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

        public static RpmHeaderStructureHeader FromBinaryReader(BinaryReader reader)
        {
            var converter = new ByteConverter(false);
            var header = new RpmHeaderStructureHeader
            {
                Magic = reader.ReadBytes(3),
                Version = reader.ReadByte(),
                Reserved = reader.ReadBytes(4),
                IndexCount = converter.ToInt32(reader.ReadBytes(4), 0),
                ByteCount = converter.ToInt32(reader.ReadBytes(4), 0),
            };

            if (!ArrayCompare.ArrayEquals(header.Magic, MagicBytes))
            {
                throw new InvalidOperationException("Magic bytes not found in Header Structure Header");
            }

            return header;
        }
    }
}
