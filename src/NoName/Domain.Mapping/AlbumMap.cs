using Domain.Audio;

namespace Domain.Mapping
{
    public class AlbumMap : EntityMap<Album>
    {
        public AlbumMap()
        {
            Map(x => x.AlbumName).Not.Nullable();
            Map(x => x.AlbumArt).Length(10485760);
            References(x => x.Artist).Cascade.SaveUpdate();
        }
    }
}