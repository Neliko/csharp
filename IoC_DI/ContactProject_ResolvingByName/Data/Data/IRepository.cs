using System.Collections.Generic;

namespace Data.Data
{
    interface IRepository<TEntity> where TEntity : IEntity
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        TEntity GetById(long id);

        IReadOnlyCollection<TEntity> GetAll();
    }
}
