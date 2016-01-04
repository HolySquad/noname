namespace Domain.Audio
{
    public class AudioFile : MediaFile
    {
        protected AudioFile()
        {
        }

        public AudioFile(string name, string filename, string path, FileType type) : base(name, filename, path, type)
        {
        }

        //TODO need to think about what we can add here
        public virtual string Format { get; protected set; }
    }
}