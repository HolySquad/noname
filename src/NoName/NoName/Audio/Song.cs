using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Audio
{
    public class Song : AudioFile
    {
        //TODO need to think about methods Play/Stop/etc.
        public Artist Artist { get; protected set; }
        public Album Album { get; protected set; }
        public TimeSpan Duration { get; protected set; }

        public Song(Artist artist, Album album, TimeSpan duration)
        {
            Artist = artist;
            Album = album;
            Duration = duration;
        }
    }
}