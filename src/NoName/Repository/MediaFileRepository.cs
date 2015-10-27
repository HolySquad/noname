using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Audio;
using Repository.Interfaces;

namespace Repository
{
    class MediaFileRepository:Repository, IMediaFileRepository
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
                    tran.Rollback();
                }
            }
        }
    }
}
