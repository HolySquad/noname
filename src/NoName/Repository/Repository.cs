using System;
using Domain;
using NHibernate;
using Repository.Interfaces;
using Utils;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly ISession _session;
        private readonly ISessionManager _sessionManager;

        protected Repository(ISessionManager sessionManager)
        {
            try
            {
                _sessionManager = sessionManager;
                _session = _sessionManager.GetSession();
            }
            catch (Exception ex) { Logger.AddToLog(ex); }
        }

        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.Save(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }

        public void SaveUpdate<TEntity>(TEntity entity) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }

        public void Delete<TEntity>(long id)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var entity = _session.Get<Entity>(id);
                    _session.Delete(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex);
                    tran.Rollback();
                }
            }
        }

        public TEntity GetEntityById<TEntity>(long id) where TEntity : Entity
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    var res = _session.Get<TEntity>(id);
                    tran.Commit();
                    return res;
                }
                catch (Exception e)
                {
                    Logger.AddToLog(e);
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}