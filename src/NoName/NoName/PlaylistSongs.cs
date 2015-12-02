using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Audio;

namespace Domain
{
    public class PlaylistSongs : Entity
    {
        [Obsolete]
        public PlaylistSongs()
        {
        }

        [Key, Column(Order = 0)]
        public virtual Playlist Playlist { get; set; }

        [Key, Column(Order = 1)]
        public virtual Song Song { get; set; }
    }
}