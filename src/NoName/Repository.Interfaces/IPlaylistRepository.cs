using System.Collections.Generic;
using Domain;
using Domain.DTO;

namespace Repository.Interfaces
{
    public interface IPlaylistRepository : IRepository
    {
        void AddPlaylist(Playlist playlist);
        IList<PlaylistListDto> GetAllPlaylists();
        void DeletePlaylist(long id);
    }
}