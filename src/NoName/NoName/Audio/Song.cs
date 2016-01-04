using System;
using System.Collections.Generic;

namespace Domain.Audio
{
    public class Song : AudioFile
    {
        public Song(Artist artist, Album album, TimeSpan duration, string name, string path, string fileName,
            FileType type) : base(name, fileName, path, type)
        {
            Artist = artist;
            Album = album;
            Duration = duration;
        }

        [Obsolete]
        public Song()
        {
        }

        //TODO need to think about methods Play/Stop/etc.

        public virtual Artist Artist { get; protected set; }
        public virtual Album Album { get; protected set; }
        public virtual TimeSpan Duration { get; protected set; }
        public virtual IList<PlaylistSongs> PlaylistSongs { get; protected set; }
    }
}