using System;
using System.Globalization;
using System.IO;

namespace Utils
{
    public class Logger
    {
        private static string _log;
        private static string _directory = @"C:\HolyStream\logs\" + DateTime.Today.ToString("dd-MM-yy")+"\\";

        private static string _filename = "logs.log";

        public static string Folder
        {
            private get { return _directory; }
            set
            {
                //AddToLog("Log file directory changed to " + value);
                _directory = value;
            }
        }

        public static string FileName
        {
            private get { return _filename; }
            set
            {
                //AddToLog("Log file name changed to '" + value + ".txt'");
                _filename = value;
            }
        }

        public static void AddToLog(string a)
        {
            _log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(Exception exargs)
        {
            _log += Environment.NewLine + "[" + DateTime.Now + "] ";
            _log += $"\n\tException: {exargs.Message}\n\tStack trace: {exargs.StackTrace}";
            ExportToFileDefaultDirectory();
        }

        public static void AddToLog(string a, Exception exargs)
        {
            _log += Environment.NewLine + "[" + DateTime.Now + "] " + a;
            _log += $"\n\tException: {exargs.Message}\n\tStack trace: {exargs.StackTrace}";
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
            return string.Format("Log ({0}): {1}", DateTime.Now, _log);
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public static void SaveMediaFileLog(string name)
        {
            FileName = "logsMedia.log";
            AddToLog("File added. Name: " + name);
            FileName = "logs.log";
        }
    }
}