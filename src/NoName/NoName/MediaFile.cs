using System;

namespace Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public abstract class MediaFile : Entity
    {
        //TODO somewhere here we need to scan files/read tags and some other stuff
        public virtual string Name { get; protected set; }
        public virtual string Path { get; protected set; }

        [Obsolete]
        protected MediaFile()
        {
        }
    }
}