namespace PackageManagement.Rpm
{
    using System.IO;

    public class RpmHeaderIndex
    {
        public int Tag;

        public TagType Type;

        public int Offset;

        public int Count;

        public static RpmHeaderIndex FromStream(Stream input)
        {
            using (var reader = new BinaryReader2(input, false))
            {
                return new RpmHeaderIndex
                {
                    Tag = reader.ReadInt32(),
                    Type = (TagType)reader.ReadInt32(),
                    Offset = reader.ReadInt32(),
                    Count = reader.ReadInt32(),
                };
            }
        }
    }
}
