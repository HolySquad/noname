using System;
using Domain.Audio;

namespace Factories
{
    public static class SongFactory
    {
        public static Song CreateAudioFile(string pathToSong)
        {
            //TODO make same for artist , album
            //need some scanService and tag reader :)
            return new Song(new Artist(), new Album() , new TimeSpan());
        }
    }
}