using Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DebugInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            FileScanner.ScanFolder(@"C:\Music");
            var files = MediaFile.Files;
        }
    }
}
