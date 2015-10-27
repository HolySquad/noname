using System;
using System.Collections.Generic;

namespace Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MediaFile : Entity
    {
        public static readonly List<MediaFile> files = new List<MediaFile>();

        [Obsolete]
        protected MediaFile()
        {
        }

        public MediaFile(string name, string path)
        {
            Name = name;
            Path = path;
        }

        //TODO somewhere here we need to scan files/read tags and some other stuff
        public virtual string Name { get; protected set; }
        public virtual string Path { get; protected set; }
    }
}