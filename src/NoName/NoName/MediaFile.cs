﻿namespace NoName
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    internal abstract class MediaFile
    {
        public string Name { get; protected set; }
        public string Path { get; protected set; }
        public int ID { get; protected set; }
    }
}