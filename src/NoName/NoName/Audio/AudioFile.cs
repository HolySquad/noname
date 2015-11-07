using System;

namespace Domain.Audio
{
    public class AudioFile : MediaFile
    {
        
        //TODO need to think about what we can add here
        public virtual string Format { get; protected set; }

       
        protected AudioFile()
        {
        }

        public AudioFile(string name, string path) : base (name, path)
        {
           
        }
    }
}
