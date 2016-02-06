using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Audio;
using NHibernate.Criterion;
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
                    Logger.LogMediafileAdded(mediafile.Name);
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to add media file.", ex);
                    tran.Rollback();
                }
            }
        }

        public IList<Song> GetAllFiles()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.QueryOver<Song>()
                        .List().OrderByDescending(x=>x.CreatedOn).ToList();
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

        public int GetFileCount()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.QueryOver<Song>().List().Count;
                    return res;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Method \'GetFilesCount\' failed.", ex);
                    tran.Rollback();
                    return 0;
                }
            }
        }

        public IList<Song> SearchItemByString(string searchString)
        {
            Album album = null;
            Song song = null;
            Artist artist = null;

            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var albumResult = _session.QueryOver<Song>()
                        .JoinAlias(x => x.Album, () => album)
                        .Where(() => album.AlbumName.IsLike(searchString, MatchMode.Anywhere)).Future();

                    var artistResult = _session.QueryOver<Song>()
                        .JoinAlias(x => x.Album, () => album)
                        .JoinAlias(()=> album.Artist, () => artist)
                        .Where(() => artist.Name.IsLike(searchString, MatchMode.Anywhere)).Future();

                    var songResult = _session.QueryOver<Song>()
                        .Where(x => x.Name.IsLike(searchString, MatchMode.Anywhere)).Future();

                    var songs = new List<Song>();
                    songs.AddRange(albumResult);
                    songs.AddRange(artistResult);
                    songs.AddRange(songResult);

                    return songs.OrderBy(x=>x.Name).ToList();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Method \'Search\' failed.", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}