﻿using Domain.Audio;
using FluentNHibernate.Mapping;

namespace Domain.Mapping
{
    public class SongMap : SubclassMap<Song>
    {
        public SongMap()
        {
            Map(x => x.Duration).Not.Nullable();
            References(x => x.Album).Cascade.SaveUpdate();
            HasMany(x => x.PlaylistSongs).Cascade.SaveUpdate().Inverse();
        }
    }
}