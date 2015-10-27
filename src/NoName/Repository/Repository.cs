using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using NHibernate;
using Repository.Interfaces;

namespace Repository
{
    public abstract class Repository: IRepository
    {
        protected readonly ISession _session = SessionManager.Instance.GetSession();
        public void Save<TEntity>(TEntity entity) where TEntity : Entity
        {
            _session.Save(entity);
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
        //{
        //    throw new NotImplementedException();
        //}
    }
}
