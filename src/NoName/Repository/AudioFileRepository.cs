using System;
using Domain.Audio;
using Repository.Interfaces;

namespace Repository
{
    internal class AudioFileRepository : Repository, IAudioFileRepository
    {
        public AudioFileRepository(ISessionManager sessionManager) : base(sessionManager)
        {
        }

        public void AddAudioFile(AudioFile audiofile)
        {
            throw new NotImplementedException();
        }
    }
}