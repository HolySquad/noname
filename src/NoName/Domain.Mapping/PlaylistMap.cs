namespace Domain.Mapping
{
    public class PlaylistMap : EntityMap<Playlist>
    {
        public PlaylistMap()
        {
            Map(x => x.PlaylistName).Not.Nullable();
            Map(x => x.PlaylistLenght).Not.Nullable();
            Map(x => x.SongCount).Not.Nullable();
            HasMany(x => x.PlaylistSongs).Cascade.SaveUpdate().Inverse();
        }
    }
}