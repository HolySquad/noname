using System.IO;
using Domain;
using Domain.Audio;
using Id3;

namespace Factories
{
    public static class SongFactory
    {
       

        public static Song CreateSong(string pathToSong)
        {
            Id3Tag[] tags = null;
           
            Song song = null;
            Mp3File file = new Mp3File(pathToSong);
            tags = file.GetAllTags();
            Id3Tag tag = tags[0];


            var artist = new Artist(tag.Album.Value);
            var album = new Album(tag.Album.Value, artist, new Genre(tag.Genre.Value), tag.Year.AsDateTime);
            song  = new Song(artist, album, file.Audio.Duration, tag.Title, pathToSong, Path.GetFileName(pathToSong));


          
              //  song = new Song(tag.Artists, tag.Album, file.Audio.Duration,tag.Title);
                
            
            return song;
        }
    }
}