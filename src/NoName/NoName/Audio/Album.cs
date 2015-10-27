using System;

namespace Domain.Audio
{
    public class Album
    {
        //TODO one of most wanted feature album art
        public Artist Artist { get; protected set; }
        public Genre Genre { get; protected set; }
        public TimeSpan Duration { get; protected set; }
        public byte TracksNumber { get; protected set; }
        public DateTime ReleaseDate { get; protected set; }
    }
}
