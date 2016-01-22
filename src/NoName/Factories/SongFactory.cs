using System.IO;
using System.Linq;
using Domain;
using Domain.Audio;
using Id3;
using Utils;

namespace Factories
{
    public static class SongFactory
    {
        public static Song CreateSong(string pathToSong)
        {
            Id3Tag[] tags = null;

            Song song = null;
            var file = new Mp3File(pathToSong);
            var type = (FileType) EnumUtil.EnumValueOf(Path.GetExtension(pathToSong), typeof (FileType));
            if (file.HasTags)
            {
                tags = file.GetAllTags();
                var tag = tags[0];
                var artist = new Artist(tag.Artists.Value);
                var album = new Album(tag.Album.Value, artist, new Genre(tag.Genre.Value), tag.Year.AsDateTime, tag.Pictures.Select(x=>x.PictureData).First());
                song = new Song(artist, album, file.Audio.Duration, tag.Title, pathToSong, Path.GetFileName(pathToSong),
                    type);
            }
            else
            {
                var artist = new Artist("Unknown Artist");
                var album = new Album("Unknown Album", artist, new Genre("Unknown Genre"), null);
                song = new Song(artist, album, file.Audio.Duration, Path.GetFileName(pathToSong), pathToSong,
                    Path.GetFileName(pathToSong), type);
            }
            return song;
        }
    }
}