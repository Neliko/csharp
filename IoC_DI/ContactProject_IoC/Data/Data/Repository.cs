using System;
using System.Collections.Generic;
using System.Linq;
using Data.Infrostructure;

namespace Data.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity :  IEntity
    {    
        protected List<TEntity> Storage = new List<TEntity>();
        private readonly IExceptionHandler _exceptionHandler;

        public EntityRepository(IExceptionHandler exceptionHandler)
        {
            if (exceptionHandler == null)
            {
                throw new Exception("Необходимо указать exceptionHandler");
            }
            _exceptionHandler = exceptionHandler;   
        }
        public void Add(TEntity entity)
        {
            try
            {
                Storage.Add(entity);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity entity)
        {
            Storage.Remove(entity);
        }

        public TEntity GetById(long id)
        {
            return Storage.First(x => x.Id == id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return Storage;
        }
    }
}
