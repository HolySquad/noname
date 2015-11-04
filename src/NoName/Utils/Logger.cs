using System;
using System.IO;
using System.Diagnostics;

namespace Utils
{
    public class Logger
    {
        private static string Log;
        private static string directory = @"C:\Users\"+ Environment.UserName + @"\Documents\HolyStream\logs\";
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

        public Logger() { }

        public static void AddToLog(string a)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(Exception exargs)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] ";
            Log += String.Format("\n\tException: {0}\n\tStack trace: {1}", exargs.Message, exargs.StackTrace);
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(string a, Exception exargs)
        {
            Log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            Log += String.Format("\n\tException: {0}\n\tStack trace: {1}", exargs.Message, exargs.StackTrace);
            ExportToFileDefaultDirectory();
        }

        public static void ExportToFileDefaultDirectory()
        {
            try
            {
                if(!Directory.Exists(Folder))
                {
                    Directory.CreateDirectory(Folder);
                }
                using (StreamWriter file = new StreamWriter(Folder +  FileName, true))
                    file.WriteLine(ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExportToFileCustomDirectory(string pathWithoutFilename)
        {
            AddToLog("Log exported to file (" + pathWithoutFilename + "\\" + FileName + ".txt)");
            try
            {
                using (StreamWriter file = new StreamWriter(Folder + "\\" + FileName + ".txt", false))
                    file.WriteLine(ToString());
            }
            catch(Exception e)
            {
                AddToLog(string.Format(@"An attempt to export log to file has failed.
                    \n\t Exception message is as follows: {0} \n\t Stack trace: \t {1}", e.Message, e.StackTrace));

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