namespace Domain.Mapping
{
    public class PlaylistMap : EntityMap<Playlist>
    {
        public PlaylistMap()
        {
            Map(x => x.PlaylistName).Not.Nullable();
            Map(x => x.PlaylistLenght).Nullable();
            Map(x => x.Comments).Nullable();
            Map(x => x.SongCount).Nullable();
            HasMany(x => x.PlaylistSongs).Cascade.SaveUpdate().Inverse();
        }
    }
}