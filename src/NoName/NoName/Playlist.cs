using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Audio;

namespace Domain
{
    public class Playlist: Entity
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

        //public virtual void UpdateLenght()
        //{
        //    foreach (var song in ListOfSongs)
        //    {
        //        PlaylistLenght = PlaylistLenght + song.Duration;
        //    }
            
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
