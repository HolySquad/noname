using System;
using Domain;
using NHibernate;
using Repository.Interfaces;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly ISession _session;
        private readonly ISessionManager _sessionManager;

        protected Repository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            _session = _sessionManager.GetSession();
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
                    tran.Rollback();
                    return null;
                }
            }
        }
    }
}