namespace Domain.Mapping
{
    public class PlaylistSongsMap : EntityMap<PlaylistSongs>
    {
        public PlaylistSongsMap()
        {
            References(x => x.Playlist);
            References(x => x.Song);
        }
    }
}