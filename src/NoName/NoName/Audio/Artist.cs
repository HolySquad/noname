using System;
using System.Collections.Generic;

namespace Domain.Audio
{
    public class Artist : Entity
    {
        public Artist(string name, string description)
        {
            Name = name;
            Description = description;
        }
        //TODO one the most wanted feature, artist art :)
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual IList<Album> AlbumsList { get; protected set; }
        public virtual IList<Song> SongsList { get; protected set; }

        public Artist(string name)
        {
            Name = name;
        }

        [Obsolete]
        protected Artist()
        {
        }
    }
}
