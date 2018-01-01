namespace PackageManagement.Rpm
{
    using System.IO;

    public class RpmHeaderIndex
    {
        public int Tag;

        public IndexType Type;

        public int Offset;

        public int Count;

        public static RpmHeaderIndex FromBinaryReader(BinaryReader reader)
        {
            var converter = new ByteConverter(false);
            return new RpmHeaderIndex
            {
                Tag = converter.ToInt32(reader.ReadBytes(4), 0),
                Type = (IndexType)converter.ToInt32(reader.ReadBytes(4), 0),
                Offset = converter.ToInt32(reader.ReadBytes(4), 0),
                Count = converter.ToInt32(reader.ReadBytes(4), 0),
            };
        }
    }
}
