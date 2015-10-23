namespace NoName
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public abstract class MediaFile
    {
        //TODO somewhere here we need to scan files/read tags and some other stuff
        public string Name { get; protected set; }
        public string Path { get; protected set; }
    }
}