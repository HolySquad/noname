using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PlaylistListDto
    {
        public long Id { get; set; }
        public string PlaylistName { get; set; }
        public TimeSpan PlaylistLenght { get; set; }
        public int SongCount { get; set; }
        public string Comments { get; set; }
    }
}
