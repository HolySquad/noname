using System.IO;
using Domain;
using Domain.Audio;
using Id3;
using Utils;

namespace Factories
{
    public static class PlaylistFactory
    {
        public static Playlist CreatePlaylist(string name, string comment)
        {
            var playlist = new Playlist(name, comment);
            
            return playlist;
        }
    }
}