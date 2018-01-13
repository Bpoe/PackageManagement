namespace PackageManagement.Rpm.Library
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

        public void Write(Stream output)
        {
            throw new NotImplementedException();
            var converter = new ByteConverter(false);
            output.Write(this.Magic, 0, this.Magic.Length);
            output.WriteByte(this.Major);
            output.WriteByte(this.Minor);
            output.Write(converter.GetBytes((short)this.Type), 0, 2);
            output.Write(converter.GetBytes(this.ArchNum), 0, 2);
            //output.Write(converter.GetBytes(this.Name);
        }

        public static RpmLead FromStream(Stream input)
        {
            using (var reader = new BinaryReader2(input, false))
            {
                var lead = new RpmLead
                {
                    Magic = reader.ReadBytes(4),
                    Major = reader.ReadByte(),
                    Minor = reader.ReadByte(),
                    Type = (PackageType)reader.ReadInt16(),
                    ArchNum = reader.ReadInt16(),
                    Name = NullTerminatedCharArray.GetString(reader.ReadChars(66)),
                    OsNum = reader.ReadInt16(),
                    SignatureType = reader.ReadInt16(),
                    Reserved = reader.ReadChars(16),
                };

                if (!ArrayCompare.ArrayEquals(lead.Magic, MagicBytes))
                {
                    throw new InvalidOperationException("Magic bytes not found in Lead");
                }

                return lead;
            }
        }
    }
}
