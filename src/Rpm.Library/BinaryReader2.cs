namespace PackageManagement.Rpm.Library
{
    using System.IO;
    using System.Text;
    
    public class BinaryReader2 : BinaryReader
    {
        private ByteConverter converter;

        public BinaryReader2(Stream input, bool isLittleEndian)
            : base(input, Encoding.UTF8, true)
        {
            this.converter = new ByteConverter(isLittleEndian);
        }

        public override short ReadInt16()
        {
            var bytes = this.ReadBytes(2);
            return this.converter.ToInt16(bytes, 0);
        }

        public override int ReadInt32()
        {
            var bytes = this.ReadBytes(4);
            return this.converter.ToInt32(bytes, 0);
        }
    }
}
