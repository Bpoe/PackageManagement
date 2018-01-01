namespace PackageManagement.Rpm
{
    using System;
    public static class NullTerminatedCharArray
    {
        public static string GetString(char[] chars)
        {
            var nullTerminator = Array.IndexOf(chars, '\0');
            if (nullTerminator < 0)
            {
                nullTerminator = chars.Length;
            }

            return new string(chars, 0, nullTerminator);
        }
    }
}
