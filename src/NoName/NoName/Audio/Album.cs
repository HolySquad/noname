using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Audio
{
    class Album
    {
        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public byte TracksNumber { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
