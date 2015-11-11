using Domain.Audio;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    internal class AudioFileMap : SubclassMap<AudioFile>
    {
        public AudioFileMap()
        {
            Map(x => x.Format).Nullable();
        }
    }
}