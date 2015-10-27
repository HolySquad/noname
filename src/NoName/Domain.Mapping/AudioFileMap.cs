using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Audio;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    class AudioFileMap : SubclassMap<AudioFile>
    {
        public AudioFileMap()
        {
            Map(x => x.Format).Not.Nullable();
        }

    }
}
