using Domain.Audio;

namespace Domain.Mapping
{
    public class AlbumMap : EntityMap<Album>
    {
        public AlbumMap()
        {
            Map(x => x.AlbumName).Nullable();
            References(x => x.Artist).Cascade.SaveUpdate();
        }
    }
}