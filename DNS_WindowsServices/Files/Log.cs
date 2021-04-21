using System;
using System.IO;

namespace DNS_WindowsServices.Files
{
    class Log
    {
        private static StreamWriter _sw;
        private const string LogFileLocation = @"C:\DDNS_WindowsService\Logs";

        private static void Utils(string context)
        {
            if (!Directory.Exists(LogFileLocation))
                Directory.CreateDirectory(LogFileLocation);
            _sw = new StreamWriter(LogFileLocation + @"\" + DateTime.Now.ToString("yyyy_MM_dd") + ".log", true);
        }

        public static void Out(string context)
        {
            Utils(context);
            _sw.Write(context);
            _sw.Flush();
            _sw.Close();
        }

        public static void OutLine(string context)
        {
            Utils(context);
            _sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " >>  " + context);
            _sw.Flush();
            _sw.Close();
        }

        private static void AutoDelete()
        {
            //
        }

    }
}
