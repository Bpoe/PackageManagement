namespace PackageManagement
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public static class StartProcess
    {
        public static Process AndWait(string fileName, string arguments)
        {
            var process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();

            return process;
        }
    }
}
