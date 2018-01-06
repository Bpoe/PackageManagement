namespace PackageManagement
{
    using System.Collections.Generic;
    using System.IO;
    public static class Extensions
    {
        public static IList<string> ReadLines(this StreamReader reader)
        {
            var lines = new List<string>();
            while(!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            return lines;
        }

        public static IDictionary<string, string> ToDictionary(this StreamReader reader)
        {
            var values = new Dictionary<string, string>();

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var index = line.IndexOf(':');
                if (index < 1)
                {
                    continue;
                }

                var key = line.Substring(0, index).Trim();
                var value = line.Substring(index + 1).Trim();
                
                values.Add(key, value);
            }

            return values;
        }
    }
}
