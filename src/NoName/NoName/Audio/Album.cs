using System;

namespace Domain.Audio
{
    public class Album : Entity
    {
        public Album(string albumName, Artist artist, Genre genre, TimeSpan duration, byte tracksNumber, DateTime releaseDate)
        {
            AlbumName = albumName;
            Artist = artist;
            Genre = genre;
            Duration = duration;
            TracksNumber = tracksNumber;
            ReleaseDate = releaseDate;
        }
        //TODO one of most wanted feature album art
        public virtual string AlbumName { get; protected set; }
        public virtual Artist Artist { get; protected set; }
        public virtual Genre Genre { get; protected set; }
        public virtual TimeSpan Duration { get; protected set; }
        public virtual byte TracksNumber { get; protected set; }
        public virtual DateTime ReleaseDate { get; protected set; }


        [Obsolete]
        protected Album()
        {
        }
    }
}
