using System.ComponentModel;

namespace Domain
{
    public enum FileType
    {
        Undefined = 0,
        [Description(".mp3")]
        Mp3 = 1,
        [Description(".wma")]
        Wma = 2,
        [Description(".flac")]
        Flac = 3,
        [Description(".mp4")]
        Mp4 = 4,
        [Description(".mov")]
        Mov = 5,
        [Description(".mpeg")]
        Mpeg = 6,
    }


}
