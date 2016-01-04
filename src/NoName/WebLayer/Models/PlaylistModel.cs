using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.DTO;

namespace WebLayer.Models
{
    public class PlaylistModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PlaylistName { get; set; }


        public string Comments { get; set; }

        [Display(Name = "Lenght")]
        public TimeSpan PlaylistLenght { get; protected set; }

        [Display(Name = "Songs")]
        public int SongCount { get; protected set; }


        public void PlaylistToModel(PlaylistListDto playlist)
        {
            Id = playlist.Id;
            PlaylistName = playlist.PlaylistName;
            PlaylistLenght = playlist.PlaylistLenght;
            SongCount = playlist.SongCount;
            Comments = playlist.Comments;
        }

    }
}