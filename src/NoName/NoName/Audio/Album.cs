using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Audio
{
    class Album
    {
        public Artist Artist { get; protected set; }
        public Genre Genre { get; protected set; }
        public TimeSpan Duration { get; protected set; }
        public byte TracksNumber { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
    }
}
