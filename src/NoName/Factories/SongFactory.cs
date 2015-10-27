using System;
using Domain.Audio;

namespace Factories
{
    internal static class SongFactory
    {
        public static Song CreateAudioFile()
        {
            //TODO make same for artist , album
            //need some scanService and tag reader :)
            return new Song(new Artist(), new Album() , new TimeSpan());
        }
    }
}