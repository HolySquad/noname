using System.IO;
using Factories;

namespace Repository
{
    public static class FileScanner
    {
        public static void ScanFolder(string path)
        {
            // Process the list of files found in the directory.
            var fileEntries = Directory.GetFiles(path);
            foreach (var fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(path);
            foreach (var subdirectory in subdirectoryEntries)
                ScanFolder(subdirectory);
        }

        public static void ProcessFile(string path)
        {
         
        }
    }
}