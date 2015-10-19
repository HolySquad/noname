using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoName.Audio
{
    class Song : AudioFile
    {
        public Artist Artist { get; protected set; }
        public Album Album { get; protected set; }
        public TimeSpan Duration { get; protected set; }
    }
}

//test git 