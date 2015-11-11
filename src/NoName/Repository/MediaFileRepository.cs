using System;
using System.Collections.Generic;
using Domain;
using Repository.Interfaces;
using Utils;

namespace Repository
{
    public class MediaFileRepository : Repository, IMediaFileRepository
    {
        public MediaFileRepository(ISessionManager sessionManager) : base(sessionManager)
        {
        }

        public void AddMediaFile(MediaFile mediafile)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(mediafile);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to add media file.", ex);
                    tran.Rollback();
                }
            }
        }

        public IList<MediaFile> GetAllFiles()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.QueryOver<MediaFile>()
                        .List();
                    return res;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Method \'GetAllFiles\' failed.", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public void DeleteMediaFile(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var file = _session.Load<MediaFile>(id);
                    _session.Delete(file);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }
    }
}