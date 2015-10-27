using Domain;

namespace Repository.Interfaces
{
    public interface IRepository
    {
        void Save<TEntity>(TEntity entity) where TEntity : Entity;
        void Update<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(long id);
        //T GetItemById<T>(long id) where T : Entity;
    }
}