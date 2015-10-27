using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;

namespace ServerGUI
{
    public static class FileScanner
    {
        public static void ScanFolder(string path)
        {
            //list of supported Files
            var ext = new List<string> {".mp3", ".flac", ".m4a"};
            // Process the list of files found in the directory.
            var fileEntries = Directory.GetFiles(path)
                .Where(f => ext.Any(x => f.EndsWith(x)));

            foreach (var fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            var subdirectoryEntries = Directory.GetDirectories(path);
            foreach (var subdirectory in subdirectoryEntries)
                ScanFolder(subdirectory);
        }

        public static void ProcessFile(string path)
        {
            var win = MainWindow.Instance;
            win.FileListBox.Items.Add(path);
            win.InfoBar.Text = win.FileListBox.Items.Count.ToString();
            var mediaFile = new MediaFile(Path.GetFileName(path), path);
            MediaFile.files.Add(mediaFile);
        }
    }
}