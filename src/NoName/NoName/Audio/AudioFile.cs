using System;

namespace Domain.Audio
{
    public class AudioFile : MediaFile
    {
        [Obsolete]
        protected AudioFile()
        {
        }

        //TODO need to think about what we can add here
        public virtual string Format { get; protected set; }
    }
}