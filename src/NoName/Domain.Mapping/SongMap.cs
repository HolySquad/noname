using Domain.Audio;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class SongMap : SubclassMap<Song>
    {
        public SongMap()
        {
            Map(x => x.Duration).Not.Nullable();
        }
    }
}