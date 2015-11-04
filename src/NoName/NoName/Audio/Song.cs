using System;

namespace Domain.Audio
{
    public class Song : AudioFile
    {
        protected Song(Artist artist, Album album, TimeSpan duration)
        {
            Artist = artist;
            Album = album;
            Duration = duration;
        }

        [Obsolete]
        protected Song()
        {
        }

        //TODO need to think about methods Play/Stop/etc.

        public virtual Artist Artist { get; protected set; }
        public virtual Album Album { get; protected set; }
        public virtual TimeSpan Duration { get; protected set; }
    }
}