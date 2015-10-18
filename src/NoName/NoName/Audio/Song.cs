using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Audio
{
    class Song : AudioFile
    {
        public Artist Artist => Album.Artist;
        public Album Album { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
