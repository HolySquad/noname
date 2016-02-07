﻿using System.Collections.Generic;
using Domain;
using Domain.Audio;

namespace Repository.Interfaces
{
    public interface IMediaFileRepository : IRepository
    {
        void AddMediaFile(MediaFile mediafile);
        IList<Song> GetAllFiles();
        void DeleteMediaFile(long id);
        int GetFileCount();
        IList<Song> SearchItemByString(string searchString);
        Album SearchAlbumName(string albumName);
        Artist SearchArtistName(string artistName);
    }
}