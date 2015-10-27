using Domain.Audio;

namespace Repository.Interfaces
{
    public interface IAudioFileRepository
    {
        void AddAudioFile(AudioFile audiofile);
    }
}