using System;
using System.Collections.Generic;

namespace Domain
{
    public class Playlist : Entity
    {
        [Obsolete]
        protected Playlist()
        {
        }

        public Playlist(string playlistName, string comment)
        {
            PlaylistName = playlistName;
            PlaylistLenght = TimeSpan.Zero;
            SongCount = 0;
            Comments = comment;
        }

        public virtual string PlaylistName { get; protected set; }
        public virtual TimeSpan PlaylistLenght { get; protected set; }
        public virtual int SongCount { get; protected set; }
        public virtual string Comments { get; protected set; }

        public virtual IList<PlaylistSongs> PlaylistSongs { get; protected set; }
        //    }
        //        PlaylistLenght = PlaylistLenght + song.Duration;
        //    {
        //    foreach (var song in ListOfSongs)
        //{

        //public virtual void UpdateLenght()
            
        //}
        
        //public virtual void AddSong(Song song)
        //{
        //    ListOfSongs.Add(song);
        //    SongCount++;
        //}

        //public virtual void RemoveSong(Song song)
        //{
        //    ListOfSongs.Remove(song);
        //    SongCount--;
        //}
    }
}
