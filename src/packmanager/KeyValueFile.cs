namespace PackageManagement
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public static class KeyValueFile
    {
        public static IDictionary<string, string> Read(string path)
        {
            var values = new Dictionary<string, string>();

            if (!File.Exists(path))
            {
                Trace.TraceWarning("Could not find the file {0}", path);
                return values;
            }

            var lines = File.ReadAllLines(path);
            foreach(var line in lines)
            {
                var index = line.IndexOf('=');
                if (index < 1)
                {
                    continue;
                }

                var key = line.Substring(0, index);
                var value = line.Substring(index + 1);
                
                values.Add(key, value);
            }

            return values;
        }
    }
}