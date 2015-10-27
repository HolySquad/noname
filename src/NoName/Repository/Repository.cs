
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NHibernate;
using Repository.Interfaces;
using Domain;

namespace Repository
{
    public abstract class Repository : IRepository
    {
        protected readonly ISession _session = SessionManager.Instance.GetSession();
        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Save(entity);
        }

        void IRepository.Update<TEntity>(TEntity entity)
        {
            Update(entity);
        }

        public void Delete<TEntity>(long id)
        {
            throw new System.NotImplementedException();
        }

        void IRepository.Save<TEntity>(TEntity entity)
        {
            Save(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Delete(entity);
        }

      

        //public T GetItemById<T>(long id) where T : Entity
        //}
        //    throw new NotImplementedException();
        //{
    }
}