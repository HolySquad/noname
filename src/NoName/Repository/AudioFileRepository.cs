using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Audio;
using Repository.Interfaces;

namespace Repository
{
    class AudioFileRepository:Repository, IAudioFileRepository
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
