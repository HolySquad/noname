using System;
using System.Collections.Generic;

namespace Domain
{
    public class MediaFile : Entity
    {
        public static readonly List<MediaFile> Files = new List<MediaFile>();

        [Obsolete]
        protected MediaFile()
        {
        }

        public MediaFile(string name, string filename, string path, FileType type)
        {
            Name = filename;
            Path = path;
            Type = type;
            CreatedOn = DateTime.Now;
        }

        //TODO somewhere here we need to scan files/read tags and some other stuff
        public virtual string Name { get; protected set; }
        public virtual string Path { get; protected set; }
        public virtual FileType Type { get; protected set; }
        public virtual DateTime CreatedOn { get; protected set; }

        public static void AddFile(MediaFile file)
        {
            Files.Add(file);
        }
    }
}