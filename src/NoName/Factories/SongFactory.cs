using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;
using Domain.Audio;
using Id3;
using Repository.Interfaces;

namespace Factories
{
    public class SongFactory
    {
        private readonly IMediaFileRepository _mediaFileRepository;

        public SongFactory(IMediaFileRepository mediaFileRepository)
        {
            _mediaFileRepository = mediaFileRepository;
        }

        private string GetSongName(string path)
        {
            return Path.GetFileName(path);
        }

        public Song SongAdd(string pathToSong)
        {
            lock (pathToSong)
            {
                Song song;
                var file = new Mp3File(pathToSong);
                if (file.HasTags)
                {
                    var tags = file.GetAllTags();
                    var tag = tags[0];
                    var artistName = tag.Artists.Value;
                    var albumName = tag.Album.Value;
                    var artist = CheckArtist(artistName);
                    var album = CheckAlbum(albumName);
                    if (artist != null && album != null)
                        song = new Song(artist, album, file.Audio.Duration, tag.Title, pathToSong,
                            GetSongName(pathToSong), FileType.Mp3);
                    else song = CreateNewAlbumArtist(pathToSong, tag, null, file);
                }
                else song = CreateUnknown(pathToSong, null, file);

                _mediaFileRepository.SaveUpdate(song.Artist);
                if (!string.IsNullOrEmpty(song.Album.AlbumName)) _mediaFileRepository.SaveUpdate(song.Album);
                _mediaFileRepository.SaveUpdate(song);
                return song;
            }
        }

        private Song CreateUnknown(string pathToSong, Song song, Mp3File file)
        {
            var unknowArtist = CheckArtist("Unknown Artist");
            var unknowAlbum = CheckAlbum("Unknown Album");
            if (unknowAlbum == null && unknowArtist == null)
            {
                unknowArtist = new Artist("Unknown Artist");
                unknowAlbum = new Album("Unknown Album", unknowArtist, new Genre("Unknown Genre"), null);
            }
            song = new Song(unknowArtist, unknowAlbum, file.Audio.Duration, GetSongName(pathToSong), pathToSong,
                GetSongName(pathToSong), FileType.Mp3);
            return song;
        }

        private Song CreateNewAlbumArtist(string pathToSong, Id3Tag tag, Song song, Mp3File file)
        {
            var newArtist = new Artist(tag.Artists.Value);
            var newAlbum = new Album(tag.Album.Value, newArtist, new Genre(tag.Genre.Value),
                tag.Year.AsDateTime,
                tag.Pictures.Select(x => x.PictureData).FirstOrDefault());
            song = new Song(newArtist, newAlbum, file.Audio.Duration, tag.Title, pathToSong,
                Path.GetFileName(pathToSong),
                FileType.Mp3);
            return song;
        }

        public IList<Song> MultiCreateSong(List<string> paths)
        {
            return paths.Select(SongAdd).ToList();
        }

        public Album CheckAlbum(string albumName)
        {
            var album = _mediaFileRepository.SearchAlbumName(albumName);
            return album;
        }

        public Artist CheckArtist(string artistName)
        {
            var artist = _mediaFileRepository.SearchArtistName(artistName);
            return artist;
        }
    }
}