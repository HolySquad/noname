using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Audio;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace Domain.Mapping
{
    public class SongMap :SubclassMap<Song>
    {
        public SongMap()
        {

        }

    }
}
