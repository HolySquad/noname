using System;

namespace Domain.Audio
{
    public class Song : AudioFile
    {
      
          

        //TODO need to think about methods Play/Stop/etc.

        public virtual Artist Artist { get; protected set; }
        public virtual Album Album { get; protected set; }
        public virtual TimeSpan Duration { get; protected set; }


        public Song(Artist artist, Album album, TimeSpan duration, string name, string path ) : base (name, path)
        {
            Artist = artist;
            Album = album;
            Duration = duration;
        }

        [Obsolete]
        public Song()
        {
        }
    }
}