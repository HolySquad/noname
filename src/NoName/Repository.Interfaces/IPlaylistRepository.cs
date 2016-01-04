using System.Collections.Generic;
using Domain;

namespace Repository.Interfaces
{
    public interface IPlaylistRepository : IRepository
    {
        void AddPlaylist(Playlist playlist);
        IList<Playlist> GetAllPlaylists();
        void DeletePlaylist(long id);
    }
}