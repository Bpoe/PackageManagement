namespace PackageManagement.Rpm
{
    using System;
    using System.IO;

    public class RpmLead
    {
        public static readonly byte[] MagicBytes = { 0xed, 0xab, 0xee, 0xdb };

        public byte[] Magic;

        public byte Major;
        
        public byte Minor;
    
        public PackageType Type;
    
        public short ArchNum;
    
        // Size of 66
        public string Name;
    
        public short OsNum;

        public short SignatureType;

        // size of 16
        public char[] Reserved;

        public static RpmLead FromBinaryReader(BinaryReader reader)
        {
            var lead = new RpmLead
            {
                Magic = reader.ReadBytes(4),
                Major = reader.ReadByte(),
                Minor = reader.ReadByte(),
                Type = (PackageType)ReadInt16(reader),
                ArchNum = ReadInt16(reader),
                Name = NullTerminatedCharArray.GetString(reader.ReadChars(66)),
                OsNum = ReadInt16(reader),
                SignatureType = ReadInt16(reader),
                Reserved = reader.ReadChars(16),
            };

            if (!ArrayCompare.ArrayEquals(lead.Magic, MagicBytes))
            {
                throw new InvalidOperationException("Magic bytes not found in Lead");
            }

            return lead;
        }

        private static short ReadInt16(BinaryReader reader)
        {
            var converter = new ByteConverter(false);
            return converter.ToInt16(reader.ReadBytes(2), 0);
        }
    }
}
