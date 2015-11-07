using System;
using System.IO;

namespace Utils
{
    public class Logger
    {
        private static string Log;
        private static string directory = @"C:\Users\" + Environment.UserName + @"\Documents\HolyStream\logs\";
        private static string filename = "logs.log";

        public static string Folder
        {
            private get { return directory; }
            set
            {
                AddToLog("Log file directory changed to " + value);
                directory = value;
            }
        }

        public static string FileName
        {
            private get { return filename; }
            set
            {
                AddToLog("Log file name changed to '" + value + ".txt'");
                filename = value;
            }
        }

        public static void AddToLog(string a)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(Exception exargs)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] ";
            Log += string.Format("\n\tException: {0}\n\tStack trace: {1}", exargs.Message, exargs.StackTrace);
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(string a, Exception exargs)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            Log += string.Format("\n\tException: {0}\n\tStack trace: {1}", exargs.Message, exargs.StackTrace);
            ExportToFileDefaultDirectory();
        }

        public static void ExportToFileDefaultDirectory()
        {
            try
            {
                if (!Directory.Exists(Folder))
                {
                    Directory.CreateDirectory(Folder);
                }
                using (var file = new StreamWriter(Folder + FileName, true))
                    file.WriteLine(ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public new static string ToString()
        {
            return string.Format("Log ({0}): {1}", DateTime.Now, Log);
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }
    }
}