using Domain;
using Domain.Audio;

namespace Repository.Interfaces
{
    public interface IMediaFileRepository : IRepository
    {
        void AddMediaFile(MediaFile mediafile);
    }
}