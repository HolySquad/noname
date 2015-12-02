using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class PlaylistSongsMap: EntityMap <PlaylistSongs>
    {
        public PlaylistSongsMap()
        {
            References(x => x.Playlist);
            References(x => x.Song);
        }
    }
}
