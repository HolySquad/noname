using System.Collections.Generic;
using Domain;

namespace Repository.Interfaces
{
    public interface IMediaFileRepository : IRepository
    {
        void AddMediaFile(MediaFile mediafile);
        IList<MediaFile> GetAllFiles();
    }
}