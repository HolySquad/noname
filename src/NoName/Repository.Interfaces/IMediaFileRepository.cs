using System.Collections;
using System.Collections.Generic;
using Domain;
using Domain.Audio;

namespace Repository.Interfaces
{
    public interface IMediaFileRepository : IRepository
    {
        void AddMediaFile(MediaFile mediafile);
        IList<MediaFile> GetAllFiles();
    }
}