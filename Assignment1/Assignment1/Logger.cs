using System;
using System.IO;

namespace SampleAssignment1
{
    public static class Logger
    {
        public static void Log(string Message)
        {
            using (StreamWriter logWriter = System.IO.File.AppendText(Utils.logFilePath))
            {
                logWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                logWriter.WriteLine("{0}", Message);
                logWriter.WriteLine("---\n");
            }
        }
    }
}
