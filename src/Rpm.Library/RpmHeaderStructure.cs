namespace PackageManagement.Rpm.Library
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class RpmHeaderStructure
    {
        private static ByteConverter converter = new ByteConverter(false);

        public RpmHeaderStructureHeader Header;

        public RpmHeaderIndex[] Indexes;

        public IDictionary<int, object> Tags;

        public static RpmHeaderStructure FromStream(Stream input)
        {
            var header = new RpmHeaderStructure();
            header.Header = RpmHeaderStructureHeader.FromStream(input);
            header.Indexes = new RpmHeaderIndex[header.Header.IndexCount];
            header.Tags = new Dictionary<int, object>();

            for (var x = 0; x < header.Header.IndexCount; x++)
            {
                header.Indexes[x] = RpmHeaderIndex.FromStream(input);
            }

            // Get the bytes from the Store
            var store = new byte[header.Header.ByteCount];
            var bytesRead = input.Read(store, 0, header.Header.ByteCount);

            for (var x = 0; x < header.Indexes.Length; x++)
            {
                var i = header.Indexes[x];

                switch(i.Type)
                {
                    case TagType.Char:
                        header.Tags.Add(i.Tag, ReadTypeChar(i, store));
                        break;
                    case TagType.Null:
                        break;
                    case TagType.Int8:
                        header.Tags.Add(i.Tag, ReadTypeInt8(i, store));
                        break;
                    case TagType.Int16:
                        header.Tags.Add(i.Tag, ReadTypeInt16(i, store));
                        break;
                    case TagType.Int32:
                        header.Tags.Add(i.Tag, ReadTypeInt32(i, store));
                        break;
                    case TagType.Int64:
                        header.Tags.Add(i.Tag, ReadTypeInt64(i, store));
                        break;
                    case TagType.String:
                        header.Tags.Add(i.Tag, ReadTypeString(i, store));
                        break;
                    case TagType.Bin:
                        header.Tags.Add(i.Tag, ReadTypeBin(i, store));
                        break;
                    case TagType.StringArray:
                        header.Tags.Add(i.Tag, ReadTypeStringArray(i, store));
                        break;
                    case TagType.I18NString:
                        header.Tags.Add(i.Tag, ReadTypeI18NString(i, store));
                        break;
                }
            }

            // read past null padding
            var remaining = bytesRead % 8;
            for (var x = 0; x < remaining; x++)
            {
                _ = input.ReadByte();
            }

            return header;
        }

        private static char[] ReadTypeChar(RpmHeaderIndex index, byte[] store)
        {
            var results = new char[index.Count];
            for (var i = 0; i < index.Count; i++)
            {
                results[i] = (char)store[index.Offset + i];
            }

            return results;
        }

        private static byte[] ReadTypeInt8(RpmHeaderIndex index, byte[] store)
        {
            var results = new byte[index.Count];
            for (var i = 0; i < index.Count; i++)
            {
                results[i] = store[index.Offset + i];
            }

            return results;
        }

        private static short[] ReadTypeInt16(RpmHeaderIndex index, byte[] store)
        {
            var results = new short[index.Count];
            for (var i = 0; i < index.Count; i++)
            {
                // int is 4 bytes, so move by 2 bytes each iteration
                results[i] = converter.ToInt16(store, index.Offset + (i * 2));
            }

            return results;
        }

        private static int[] ReadTypeInt32(RpmHeaderIndex index, byte[] store)
        {
            var results = new int[index.Count];
            for (var i = 0; i < index.Count; i++)
            {
                // int is 4 bytes, so move by 4 bytes each iteration
                results[i] = converter.ToInt32(store, index.Offset + (i * 4));
            }

            return results;
        }

        private static long[] ReadTypeInt64(RpmHeaderIndex index, byte[] store)
        {
            var results = new long[index.Count];
            for (var i = 0; i < index.Count; i++)
            {
                // int is 4 bytes, so move by 8 bytes each iteration
                results[i] = converter.ToInt64(store, index.Offset + (i * 8));
            }

            return results;
        }

        private static string ReadTypeString(RpmHeaderIndex index, byte[] store)
        {
            var sb = new StringBuilder();
            var i = index.Offset;
            while (store[i] != 0)
            {
                sb.Append((char)store[i]);
                i++;
            }

            return sb.ToString();
        }

        private static byte[] ReadTypeBin(RpmHeaderIndex index, byte[] store)
        {
            return ReadTypeInt8(index, store);
        }

        private static string[] ReadTypeStringArray(RpmHeaderIndex index, byte[] store)
        {
            var results = new string[index.Count];
            var resultsIndex = 0;
            var storeIndex = index.Offset;

            var sb = new StringBuilder();

            while (resultsIndex < index.Count)
            {
                while (store[storeIndex] != 0)
                {
                    sb.Append((char)store[storeIndex]);
                    storeIndex++;
                }

                storeIndex++;

                results[resultsIndex] = sb.ToString();
                sb.Clear();
                resultsIndex++;
            }

            return results;
        }

        private static string[] ReadTypeI18NString(RpmHeaderIndex index, byte[] store)
        {
            var results = new string[index.Count];
            var resultsIndex = 0;
            var storeIndex = index.Offset;

            var sb = new StringBuilder();

            while (resultsIndex < index.Count)
            {
                while (store[storeIndex] != 0)
                {
                    sb.Append((char)store[storeIndex]);
                    storeIndex++;
                }

                storeIndex++;

                results[resultsIndex] = sb.ToString();
                sb.Clear();
                resultsIndex++;
            }

            return results;
        }
    }
}
