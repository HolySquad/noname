using Domain.Audio;

namespace Domain.Mapping
{
    public class ArtistMap : EntityMap<Artist>
    {
        public ArtistMap()
        {
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
        }
    }
}