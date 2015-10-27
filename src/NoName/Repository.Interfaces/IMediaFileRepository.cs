using Domain;
using Domain.Audio;

namespace Repository.Interfaces
{
    public interface IMediaFileRepository
    {
        void AddMediaFile(MediaFile mediafile);
    }
}