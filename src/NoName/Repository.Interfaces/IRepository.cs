using FluentNHibernate.Data;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
        //T GetItemById<T>(long id) where T : Entity;
    }
}