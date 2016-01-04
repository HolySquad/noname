using System;
using System.Collections.Generic;
using Domain;
using Domain.Audio;
using Domain.DTO;
using NHibernate.Transform;
using Repository.Interfaces;
using Utils;

namespace Repository
{
    public class PlaylistRepository : Repository, IPlaylistRepository
    {
        public PlaylistRepository(ISessionManager sessionManager)
            : base(sessionManager)
        {
        }

        public void AddPlaylist(Playlist playlist)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(playlist);
                    tran.Commit();
                    Logger.SaveMediaFileLog(playlist.PlaylistName);
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Failed to add media file.", ex);
                    tran.Rollback();
                }
            }
        }

        public IList<PlaylistListDto> GetAllPlaylists()
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    Playlist pl = null;
                    PlaylistListDto raw = null;

                    var res = _session.QueryOver(()=>pl)
                        .SelectList(list => list
                        .SelectGroup(()=>pl.Id).WithAlias(()=> raw.Id)
                        .SelectGroup(()=>pl.PlaylistName).WithAlias(()=>raw.PlaylistName)
                        .SelectGroup(() => pl.SongCount).WithAlias(() => raw.SongCount)
                        .SelectGroup(() => pl.PlaylistLenght).WithAlias(() => raw.PlaylistLenght)
                        .SelectGroup(() => pl.Comments).WithAlias(() => raw.Comments))
                        .TransformUsing(Transformers.AliasToBean<PlaylistListDto>())
                        .List<PlaylistListDto>();
                    return res;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog("Method \'GetAllPlaylists\' failed.", ex);
                    tran.Rollback();
                    return null;
                }
            }
        }

        public void DeletePlaylist(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var file = _session.Load<Playlist>(id);
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